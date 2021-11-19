using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Taitans.YarpManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class YarpManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<YarpManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<YarpManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Taitans/YarpManagement/Localization/YarpManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Taitans.YarpManagement", typeof(YarpManagementResource));
            });
        }
    }
}
