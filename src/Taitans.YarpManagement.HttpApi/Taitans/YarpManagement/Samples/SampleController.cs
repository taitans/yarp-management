using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Taitans.YarpManagement.Samples
{
    [Area(YarpManagementRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = YarpManagementRemoteServiceConsts.RemoteServiceName)]
    [Route("api/YarpManagement/sample")]
    public class SampleController : YarpManagementControllerBase, ISampleAppService
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleController(ISampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }

        [HttpGet]
        public async Task<SampleDto> GetAsync()
        {
            return await _sampleAppService.GetAsync();
        }

        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public async Task<SampleDto> GetAuthorizedAsync()
        {
            return await _sampleAppService.GetAsync();
        }
    }
}
