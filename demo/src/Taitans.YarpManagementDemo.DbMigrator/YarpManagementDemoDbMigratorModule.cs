using Taitans.YarpManagementDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Taitans.YarpManagementDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(YarpManagementDemoEntityFrameworkCoreModule),
    typeof(YarpManagementDemoApplicationContractsModule)
    )]
public class YarpManagementDemoDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
