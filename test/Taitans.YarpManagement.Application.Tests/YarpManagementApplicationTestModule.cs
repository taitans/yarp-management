using Volo.Abp.Modularity;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(YarpManagementApplicationModule),
        typeof(YarpManagementDomainTestModule)
        )]
    public class YarpManagementApplicationTestModule : AbpModule
    {

    }
}
