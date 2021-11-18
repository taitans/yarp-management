using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(YarpManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class YarpManagementApplicationContractsModule : AbpModule
    {

    }
}
