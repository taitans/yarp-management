using Microsoft.Extensions.Primitives;
using System.Text.Json;
using Taitans.YarpManagement;
using Volo.Abp.DependencyInjection;
using Yarp.ReverseProxy.Configuration;

namespace Taitans.Yarp.Provider.Abp.Configuration
{
    public class InDatabaseConfigProvider : IProxyConfigProvider, IUpdateConfig
    {
        private readonly IProxyConfigRepository _repository;
        private readonly ProxyConfigOptions _option;
        private volatile InDatabaseConfig _config;

        public InDatabaseConfigProvider(IProxyConfigRepository repository, ProxyConfigOptions option)
        {
            _repository = repository;
            _option = option;
        }

        public IProxyConfig GetConfig()
        {
            if (_config == null)
            { 
                var entity = _repository.GetAsync(x => x.Name == _option.Name).Result;
                var config = JsonSerializer.Deserialize<GatewayConfig>(entity.Value) ?? new GatewayConfig();
                _config = new InDatabaseConfig(config.Routes, config.Clusters);
            }

            return _config;
        }

        public void Update(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        {
            if (_config != null)
            {
                var oldConfig = _config;
                _config = new InDatabaseConfig(routes, clusters);
                oldConfig.SignalChange();
            }
        }

        private class InDatabaseConfig : IProxyConfig
        {
            private readonly CancellationTokenSource _cts = new CancellationTokenSource();

            public InDatabaseConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
            {
                Routes = routes;
                Clusters = clusters;
                ChangeToken = new CancellationChangeToken(_cts.Token);
            }

            public IReadOnlyList<RouteConfig> Routes { get; }

            public IReadOnlyList<ClusterConfig> Clusters { get; }

            public IChangeToken ChangeToken { get; }

            internal void SignalChange()
            {
                _cts.Cancel();
            }
        }
    }
}
