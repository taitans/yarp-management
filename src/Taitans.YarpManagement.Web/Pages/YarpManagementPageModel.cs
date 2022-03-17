using Taitans.YarpManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Taitans.YarpManagement.Web.Pages;

public abstract class YarpManagementPageModel : AbpPageModel
{
    protected YarpManagementPageModel()
    {
        LocalizationResourceType = typeof(YarpManagementResource);
        ObjectMapperContext = typeof(YarpManagementWebModule);
    }
}
