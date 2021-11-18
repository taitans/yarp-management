using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Yarp.ReverseProxy.Configuration;

namespace Taitans.YarpManagement
{
    public class YarpDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly IProxyConfigRepository _proxyConfigRepository;
        private readonly IGuidGenerator _guidGenerator;

        public YarpDataSeedContributor(IConfiguration configuration,
            IProxyConfigRepository proxyConfigRepository,
            IGuidGenerator guidGenerator)
        {
            _configuration = configuration;
            _proxyConfigRepository = proxyConfigRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var name = _configuration.GetSection("ReverseProxy:Name").Value;

            if (!name.IsNullOrWhiteSpace() && (await _proxyConfigRepository.GetCountByNameAsync(name)) == 0)
            {
                var routes = _configuration.GetSection("ReverseProxy:Routes").Get<RouteConfig[]>();
                var clusters = _configuration.GetSection("ReverseProxy:Clusters").Get<ClusterConfig[]>();

                var proxyConfig = new GatewayConfig
                {
                    Clusters = clusters,
                    Routes = routes
                };

                await _proxyConfigRepository.InsertAsync(new ProxyConfig(_guidGenerator.Create(), name, JsonSerializer.Serialize(proxyConfig), "00001"));
            }
        }
    }
}
