using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Taitans.YarpManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(YarpManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class YarpManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<YarpManagementDbContext>(options =>
            {
                options.AddRepository<ProxyConfig, EfCoreProxyConfigRepository>();
            });
        }
    }
}