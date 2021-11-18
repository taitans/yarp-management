using Taitans.YarpManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Taitans.YarpManagement
{
    public abstract class YarpManagementControllerBase : AbpControllerBase
    {
        protected YarpManagementControllerBase()
        {
            LocalizationResource = typeof(YarpManagementResource);
        }
    }
}
