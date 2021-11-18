using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    [DependsOn(
        typeof(YarpManagementDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class YarpManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<YarpManagementMongoDbContext>(options =>
            {
                options.AddRepository<ProxyConfig, MongoProxyConfigRepository>();
            });
        }
    }
}
