using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taitans.YarpManagement.Dtos;
using Taitans.YarpManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.EventBus.Distributed;

namespace Taitans.YarpManagement
{
    [Authorize(YarpManagementPermissions.ProxyConfigs.Default)]
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

        public virtual async Task<ProxyConfigDto> GetAsync(Guid id)
        {
            var entity = await ProxyConfigRepository.GetAsync(id);

            return ObjectMapper.Map<ProxyConfig, ProxyConfigDto>(entity);
        }

        [Authorize(YarpManagementPermissions.ProxyConfigs.Create)]
        public virtual async Task CreateAsync(CreateProxyConfigDto input)
        {
            var config = await ProxyConfigRepository.FindAsync(x => x.Name == input.Name);
            if (config != null && (config.Value?.GetHashCode() == input.Value.GetHashCode()))
            {
                return;
            }
            else if (config != null)
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

        [Authorize(YarpManagementPermissions.ProxyConfigs.ViewChangeHistory)]
        public virtual async Task<PagedResultDto<ProxyConfigHistoryDto>> GetHistoryListAsync(GetHistoryInput input)
        {
            using (DataFilter.Disable<ISoftDelete>())
            {

                var count = await ProxyConfigRepository.GetCountByNameAsync(input.Name);

                var list = (await ProxyConfigRepository.GetListAsync(sorting: nameof(ProxyConfig.IsDeleted) + " asc", name: input.Name));

                List<ProxyConfigHistoryDto> historyDtos = new();

                foreach (var history in list)
                {
                    historyDtos.Add(new ProxyConfigHistoryDto
                    {
                        Id = history.Id,
                        CreateTime = history.CreationTime,
                        IsCurrent = !history.IsDeleted,
                        Value = history.Value,
                        Version = history.Version
                    });
                }

                return new PagedResultDto<ProxyConfigHistoryDto>(
                    count,
                    ObjectMapper.Map<List<ProxyConfigHistoryDto>, List<ProxyConfigHistoryDto>>(historyDtos));
            }
        }

        [Authorize(YarpManagementPermissions.ProxyConfigs.RollBack)]
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

        [Authorize(YarpManagementPermissions.ProxyConfigs.Reload)]
        public virtual async Task ReloadAsync(Guid id)
        {
            var config = await ProxyConfigRepository.GetAsync(id);
            await DistributedEventBus.PublishAsync(new UpdateConfigurationEventData(config.Name, config.Value, Clock.Now));
        }
    }
}
