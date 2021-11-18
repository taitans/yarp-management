using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Taitans.YarpManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(YarpManagementDomainSharedModule)
    )]
    public class YarpManagementDomainModule : AbpModule
    {

    }
}
