using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Taitans.YarpManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Taitans.YarpManagement.Web.Pages;

public abstract class YarpManagementPage : AbpPage
{
    [RazorInject]
    public IHtmlLocalizer<YarpManagementResource> L { get; set; }
}
