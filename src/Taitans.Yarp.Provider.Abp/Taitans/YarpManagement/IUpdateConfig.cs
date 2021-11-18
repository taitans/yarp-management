using System;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;
using Yarp.ReverseProxy.Configuration;

namespace Taitans.Yarp.Provider.Abp
{
    public interface IUpdateConfig
    {
        void Update(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters);
    }
}
