using Volo.Abp.Studio;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace MyCompany.YarpManagement
{
    [DependsOn(
        typeof(AbpStudioModuleInstallerModule),
        typeof(AbpVirtualFileSystemModule)
        )]
    public class YarpManagementInstallerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<YarpManagementInstallerModule>();
            });
        }
    }
}
