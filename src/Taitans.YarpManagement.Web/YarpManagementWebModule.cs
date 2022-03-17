using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Taitans.YarpManagement.Localization;
using Taitans.YarpManagement.Permissions;
using Taitans.YarpManagement.Web.Navigation;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.PageToolbars;
using Volo.Abp.AutoMapper;
using Volo.Abp.Http.ProxyScripting.Generators.JQuery;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Taitans.YarpManagement.Web;

[DependsOn(
    typeof(YarpManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule))]
public class YarpManagementWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(YarpManagementResource), typeof(YarpManagementWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(YarpManagementWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    { 
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new YarpManagementMainMenuContributor());
        });
         
        context.Services.AddAutoMapperObjectMapper<YarpManagementWebModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<YarpManagementWebModuleAutoMapperProfile>(validate: true);
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<YarpManagementWebModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<YarpManagementResource>()
                .AddVirtualJson("/Taitans/YarpManagement/Localization/ApplicationContracts");
        });

        Configure<RazorPagesOptions>(options =>
        {
            //options.Conventions.AddPageRoute("/AuditLogs/Index", "AuditLogs/");
            options.Conventions.AddPageRoute("/AuditLogs/Detail", "AuditLogs/Detail/{id}");
        });

        Configure<RazorPagesOptions>(options =>
        {
            options.Conventions.AuthorizePage("/YarpManagement/ProxyConfigs/Index", YarpManagementPermissions.ProxyConfigs.Default);
            options.Conventions.AuthorizePage("/YarpManagement/ProxyConfigs/CreateModal", YarpManagementPermissions.ProxyConfigs.Create);
            options.Conventions.AuthorizePage("/YarpManagement/ProxyConfigs/EditModal", YarpManagementPermissions.ProxyConfigs.Update);
        });

        Configure<AbpPageToolbarOptions>(options =>
        {
            options.Configure<Pages.YarpManagement.ProxyConfigs.IndexModel>(
                toolbar =>
                {
                    toolbar.AddButton(
                        LocalizableString.Create<YarpManagementResource>("NewProxyConfig"),
                        icon: "plus",
                        name: "CreateProxyConfig",
                        requiredPolicyName: YarpManagementPermissions.ProxyConfigs.Create
                    );
                }
            );
        });

        //Configure<AbpBundlingOptions>(options =>
        //{
        //    options.ScriptBundles.Configure(
        //        StandardBundles.Scripts.Global,
        //        configuration =>
        //        {
        //            configuration.AddFiles("/Pages/AuditLogs/audit-log-global.js");
        //        }
        //    );
        //});

        Configure<DynamicJavaScriptProxyOptions>(options =>
        {
            options.DisableModule(YarpManagementRemoteServiceConsts.ModuleName);
        });

    }
}
