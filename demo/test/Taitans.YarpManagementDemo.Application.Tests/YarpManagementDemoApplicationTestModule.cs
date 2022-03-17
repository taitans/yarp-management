using Volo.Abp.Modularity;

namespace Taitans.YarpManagementDemo;

[DependsOn(
    typeof(YarpManagementDemoApplicationModule),
    typeof(YarpManagementDemoDomainTestModule)
    )]
public class YarpManagementDemoApplicationTestModule : AbpModule
{

}
