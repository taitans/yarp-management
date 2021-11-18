using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Taitans.YarpManagement.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
