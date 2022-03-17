using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Taitans.YarpManagement.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;
using static Taitans.YarpManagement.Web.Pages.YarpManagement.ProxyConfigs.CreateModalModel;

namespace Taitans.YarpManagement.Web.Pages.YarpManagement.ProxyConfigs;

public class EditModalModel : YarpManagementPageModel
{
    [BindProperty]
    public ProxyConfigInfoModel ProxyConfig { get; set; }

    protected IProxyConfigAppService ProxyConfigAppService;

    public EditModalModel(IProxyConfigAppService proxyConfigAppService)
    {
        ProxyConfigAppService = proxyConfigAppService;
    }

    public virtual async Task<IActionResult> OnGetAsync(Guid id)
    {
        ProxyConfig = ObjectMapper.Map<ProxyConfigDto, ProxyConfigInfoModel>(
            await ProxyConfigAppService.GetAsync(id));

        return Page();
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        ValidateModel();

        var input = ObjectMapper.Map<ProxyConfigInfoModel, CreateProxyConfigDto>(ProxyConfig);
        await ProxyConfigAppService.CreateAsync(input);

        return NoContent();
    }

    public class ProxyConfigInfoModel : ExtensibleObject, IHasConcurrencyStamp
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        [DynamicStringLength(typeof(ProxyConfigConsts), nameof(ProxyConfigConsts.MaxNameLength))]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Value")]
        [TextArea]
        public string Value { get; set; }

        [HiddenInput]
        public string ConcurrencyStamp { get; set; }
    }
}
