using Yarp.ReverseProxy.Configuration;

namespace Taitans.YarpManagement
{
    public class GatewayConfig
    {
        public ClusterConfig[] Clusters { get; set; }

        public RouteConfig[] Routes { get; set; }
    }
}
