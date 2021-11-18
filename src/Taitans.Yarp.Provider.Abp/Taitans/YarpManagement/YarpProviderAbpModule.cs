using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Taitans.Yarp.Provider.Abp.Configuration;
using Taitans.YarpManagement;
using Taitans.YarpManagement.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;

namespace Taitans.Yarp.Provider.Abp
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpEventBusRabbitMqModule),
        typeof(YarpManagementEntityFrameworkCoreModule)
    )]
    public class YarpProviderAbpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<YarpManagementDbContext>();

            context.Services.AddScoped<IProxyConfigRepository>(
                sp => sp.GetRequiredService<EfCoreProxyConfigRepository>()
            );
             
        }

    }
}
