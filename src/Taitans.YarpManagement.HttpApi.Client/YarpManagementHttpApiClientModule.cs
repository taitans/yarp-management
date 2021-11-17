using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(YarpManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class YarpManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(YarpManagementApplicationContractsModule).Assembly,
                YarpManagementRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<YarpManagementHttpApiClientModule>();
            });

        }
    }
}
