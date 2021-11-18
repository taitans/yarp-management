using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taitans.YarpManagement.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Taitans.YarpManagement
{
    [RemoteService(Name = YarpManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("YarpManagement")]
    [ControllerName("Yarp")]
    [Route("/api/yarp/proxy-config")]
    public class ProxyConfigController : YarpManagementControllerBase, IProxyConfigAppService
    {
        private readonly IProxyConfigAppService _proxyConfigAppService;

        public ProxyConfigController(IProxyConfigAppService proxyConfigAppService)
        {
            _proxyConfigAppService = proxyConfigAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<ProxyConfigDto>> GetListAsync(GetProxyConfigsInput input)
        {
            return _proxyConfigAppService.GetListAsync(input);
        }

        [HttpGet("historys")]
        public Task<List<ProxyConfigHistoryDto>> GetHistoryListAsync(GetHistoryInput input)
        {
            return _proxyConfigAppService.GetHistoryListAsync(input);
        }

        [HttpPut("{id}/roll-back")]
        public Task RollBackAsync(Guid id)
        {
            return _proxyConfigAppService.RollBackAsync(id);
        }

        [HttpPost]
        public Task CreateAsync(CreateProxyConfigDto input)
        {
            return _proxyConfigAppService.CreateAsync(input);
        }

        [HttpPut("{id}/reload")]
        public Task ReloadAsync(Guid id)
        {
            return _proxyConfigAppService.ReloadAsync(id);
        }

    }
}
