using Taitans.YarpManagement.Localization;
using Volo.Abp.Application.Services;

namespace Taitans.YarpManagement
{
    public abstract class YarpManagementAppService : ApplicationService
    {
        protected YarpManagementAppService()
        {
            LocalizationResource = typeof(YarpManagementResource);
            ObjectMapperContext = typeof(YarpManagementApplicationModule);
        }
    }
}
