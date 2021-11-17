using Taitans.YarpManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Taitans.YarpManagement
{
    public abstract class YarpManagementController : AbpControllerBase
    {
        protected YarpManagementController()
        {
            LocalizationResource = typeof(YarpManagementResource);
        }
    }
}
