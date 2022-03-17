using Taitans.YarpManagementDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Taitans.YarpManagementDemo;

[DependsOn(
    typeof(YarpManagementDemoEntityFrameworkCoreTestModule)
    )]
public class YarpManagementDemoDomainTestModule : AbpModule
{

}
