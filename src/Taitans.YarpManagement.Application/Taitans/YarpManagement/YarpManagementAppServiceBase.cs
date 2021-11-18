using Taitans.YarpManagement.Localization;
using Volo.Abp.Application.Services;

namespace Taitans.YarpManagement
{
    public abstract class YarpManagementAppServiceBase : ApplicationService
    {
        protected YarpManagementAppServiceBase()
        {
            LocalizationResource = typeof(YarpManagementResource);
            ObjectMapperContext = typeof(YarpManagementApplicationModule);
        }
    }
}
