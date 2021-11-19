using Microsoft.Extensions.Logging;
using System.Text.Json;
using Taitans.Yarp.Provider.Abp;
using Taitans.Yarp.Provider.Abp.Configuration;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Yarp.ReverseProxy.Configuration;

namespace Taitans.YarpManagement
{
    public class UpdateConfigurationEventHandler : IDistributedEventHandler<UpdateConfigurationEventData>, ITransientDependency
    {
        private readonly IProxyConfigProvider _proxyConfigProvider;
        private readonly IUpdateConfig _updateConfig;
        private readonly ILogger<UpdateConfigurationEventHandler> _logger;
        private readonly ProxyConfigOptions _options;

        public UpdateConfigurationEventHandler(IProxyConfigProvider proxyConfigProvider,
            IUpdateConfig updateConfig,
            ILogger<UpdateConfigurationEventHandler> logger,
            ProxyConfigOptions options)
        {
            _proxyConfigProvider = proxyConfigProvider;
            _updateConfig = updateConfig;
            _logger = logger;
            _options = options;
        }

        public Task HandleEventAsync(UpdateConfigurationEventData eventData)
        {
            if (_options.Name == eventData.Name)
            {
                try
                {
                    var config = JsonSerializer.Deserialize<GatewayConfig>(eventData.Value);

                    if (config == null)
                    {
                        throw new ArgumentNullException(nameof(config));
                    }

                    _updateConfig.Update(config.Routes, config.Clusters);

                    _logger.LogInformation($"gateway name: {eventData.Name} reload sucess.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"gateway name: {eventData.Name} reload fail. value:{eventData.Value}");
                }
            } 

            return Task.CompletedTask;
        }
    }
}
