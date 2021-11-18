using Localization.Resources.AbpUi;
using Taitans.YarpManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(YarpManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class YarpManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(YarpManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<YarpManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
