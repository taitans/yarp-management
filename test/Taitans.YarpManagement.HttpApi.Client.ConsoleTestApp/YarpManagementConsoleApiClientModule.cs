using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(YarpManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class YarpManagementConsoleApiClientModule : AbpModule
    {

    }
}
