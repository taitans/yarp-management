using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taitans.YarpManagement.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Taitans.YarpManagement
{
    public interface IProxyConfigAppService : IApplicationService
    {
        Task<PagedResultDto<ProxyConfigHistoryDto>> GetHistoryListAsync(GetHistoryInput input);
        Task RollBackAsync(Guid id);
        Task CreateAsync(CreateProxyConfigDto input);
        Task ReloadAsync(Guid id);
        Task<PagedResultDto<ProxyConfigDto>> GetListAsync(GetProxyConfigsInput input);
        Task<ProxyConfigDto> GetAsync(Guid id);
    }
}
