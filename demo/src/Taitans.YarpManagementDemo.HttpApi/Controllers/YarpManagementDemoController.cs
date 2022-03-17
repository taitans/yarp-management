using Taitans.YarpManagementDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Taitans.YarpManagementDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class YarpManagementDemoController : AbpControllerBase
{
    protected YarpManagementDemoController()
    {
        LocalizationResource = typeof(YarpManagementDemoResource);
    }
}
