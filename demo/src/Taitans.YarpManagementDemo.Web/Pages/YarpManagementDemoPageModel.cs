using Taitans.YarpManagementDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Taitans.YarpManagementDemo.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class YarpManagementDemoPageModel : AbpPageModel
{
    protected YarpManagementDemoPageModel()
    {
        LocalizationResourceType = typeof(YarpManagementDemoResource);
    }
}
