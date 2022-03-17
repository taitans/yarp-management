using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Taitans.YarpManagement.Web.Pages.YarpManagement.ProxyConfigs
{
    public class HistoryValueModalModel : PageModel
    {
        [BindProperty]
        public ValueMInfoModel Value { get; set; }
        public IProxyConfigAppService ProxyConfigAppService { get; }

        public HistoryValueModalModel(IProxyConfigAppService proxyConfigAppService)
        {
            ProxyConfigAppService = proxyConfigAppService;
        }


        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var dto = await ProxyConfigAppService.GetAsync(id);
            Value = new ValueMInfoModel
            {
                Value = dto.Value
            };
            return Page();
        }

        public class ValueMInfoModel
        {

            [TextArea(Rows = 20)]
            [ReadOnlyInput]
            public string Value { get; set; }

        }
    }
}
