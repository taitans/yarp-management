using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.ObjectExtending;

namespace Taitans.YarpManagement.Web.Pages.YarpManagement.ProxyConfigs
{
    public class ViewChangeHistoryModalModel : PageModel
    {
        [BindProperty]
        public ViewChangeHistoryInfoModel HistoryInfoModel { get; set; }

        protected IProxyConfigAppService ProxyConfigAppService { get; }

        public ViewChangeHistoryModalModel(IProxyConfigAppService proxyConfigAppService)
        {
            ProxyConfigAppService = proxyConfigAppService;
        }


        public async Task<IActionResult> OnGetAsync(string name)
        {
            HistoryInfoModel = new ViewChangeHistoryInfoModel
            {
                Name = name
            };
            return Page();
        }


        public class ViewChangeHistoryInfoModel : ExtensibleObject
        {
            public string Name { get; set; }

        }
    }
}
