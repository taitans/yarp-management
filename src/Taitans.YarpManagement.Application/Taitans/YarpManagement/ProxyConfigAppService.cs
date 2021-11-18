using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taitans.YarpManagement.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;

namespace Taitans.YarpManagement
{
    [Authorize]
    public class ProxyConfigAppService : YarpManagementAppServiceBase, IProxyConfigAppService
    {
        protected IProxyConfigRepository ProxyConfigRepository;
        public IDistributedEventBus DistributedEventBus { get; }

        public ProxyConfigAppService(IProxyConfigRepository proxyConfigRepository,
            IDistributedEventBus distributedEventBus)
        {
            ProxyConfigRepository = proxyConfigRepository;
            DistributedEventBus = distributedEventBus;
        }

        public virtual async Task<PagedResultDto<ProxyConfigDto>> GetListAsync(GetProxyConfigsInput input)
        {
            var count = await ProxyConfigRepository.GetCountAsync(input.Filter);
            var list = await ProxyConfigRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<ProxyConfigDto>(
                count,
                ObjectMapper.Map<List<ProxyConfig>, List<ProxyConfigDto>>(list));
        }

        public virtual async Task CreateAsync(CreateProxyConfigDto input)
        {
            var config = await ProxyConfigRepository.FindAsync(x => x.Name == input.Name);
            if (config != null && config.Value?.GetHashCode() != input.Value.GetHashCode())
            {
                await ProxyConfigRepository.DeleteAsync(config);
            }

            long count = 0;
            using (DataFilter.Disable<ISoftDelete>())
            {
                count = await ProxyConfigRepository.GetCountByNameAsync(input.Name);
            }

            config = new ProxyConfig(GuidGenerator.Create(), input.Name, input.Value, ProxyConfig.CreateCode(count + 1));

            await ProxyConfigRepository.InsertAsync(config);

        }

        public virtual async Task<List<ProxyConfigHistoryDto>> GetHistoryListAsync(GetHistoryInput input)
        {
            using (DataFilter.Disable<ISoftDelete>())
            {
                List<ProxyConfigHistoryDto> historyDtos = new();

                var list = await ProxyConfigRepository.GetListByNameAsync(input.Name);

                foreach (var history in list)
                {
                    historyDtos.Add(new ProxyConfigHistoryDto
                    {
                        CreateTime = history.CreationTime,
                        IsCurrent = !history.IsDeleted,
                        Value = history.Value,
                        Version = history.Version
                    });
                }

                return historyDtos;
            }
        }

        public virtual async Task RollBackAsync(Guid id)
        {
            using (DataFilter.Disable<ISoftDelete>())
            {
                var rollback = await ProxyConfigRepository.GetAsync(id);

                if (rollback.IsDeleted)
                {
                    //TODO:
                    await ProxyConfigRepository.DeleteAsync(x => x.Name == rollback.Name && !x.IsDeleted);

                    rollback.RollBack();

                    await ProxyConfigRepository.UpdateAsync(rollback);
                }
            }
        }

        public virtual async Task ReloadAsync(Guid id)
        {
            var config = await ProxyConfigRepository.GetAsync(id);
            await DistributedEventBus.PublishAsync(new UpdateConfigurationEventData(config.Name, config.Value, Clock.Now));
        }
    }
}
