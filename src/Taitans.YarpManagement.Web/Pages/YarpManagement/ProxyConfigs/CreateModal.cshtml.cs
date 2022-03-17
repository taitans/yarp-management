using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Taitans.YarpManagement.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Taitans.YarpManagement.Web.Pages.YarpManagement.ProxyConfigs;

public class CreateModalModel : YarpManagementPageModel
{ 
    [BindProperty]
    public ProxyConfigInfoModel ProxyConfig { get; set; }

    protected IProxyConfigAppService ProxyConfigAppService;
     
    public CreateModalModel(IProxyConfigAppService proxyConfigAppService)
    {
        ProxyConfigAppService = proxyConfigAppService;
    }

    public virtual Task OnGetAsync()
    {
        ProxyConfig = new ProxyConfigInfoModel();
        return Task.FromResult<IActionResult>(Page());
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        ValidateModel();

        var input = ObjectMapper.Map<ProxyConfigInfoModel, CreateProxyConfigDto>(ProxyConfig);
        await ProxyConfigAppService.CreateAsync(input);

        return NoContent();
    }

    public class ProxyConfigInfoModel : ExtensibleObject
    {
        [Required]
        [DynamicStringLength(typeof(ProxyConfigConsts), nameof(ProxyConfigConsts.MaxNameLength))]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Value")]
        [TextArea]
        public string Value { get; set; }
    }
}
