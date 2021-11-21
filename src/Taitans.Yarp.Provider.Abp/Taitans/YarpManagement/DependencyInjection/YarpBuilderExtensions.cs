using Microsoft.Extensions.Options;
using Taitans.Yarp.Provider.Abp;
using Taitans.Yarp.Provider.Abp.Configuration;
using Yarp.ReverseProxy.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class YarpBuilderExtensions
    {
        public static IReverseProxyBuilder AddAbpReverseProxy(this IServiceCollection services, Action<ProxyConfigOptions> option)
        {
            services.Configure(option);

            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ProxyConfigOptions>>().Value);
             
            services.AddSingleton<InDatabaseConfigProvider, InDatabaseConfigProvider>();
            services.AddSingleton<IProxyConfigProvider, InDatabaseConfigProvider>(sp => sp.GetRequiredService<InDatabaseConfigProvider>());
            services.AddSingleton<IUpdateConfig, InDatabaseConfigProvider>(sp => sp.GetRequiredService<InDatabaseConfigProvider>());

            return services.AddReverseProxy();
        }
    }
}
