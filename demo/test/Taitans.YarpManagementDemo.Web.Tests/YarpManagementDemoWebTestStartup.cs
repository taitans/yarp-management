using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Taitans.YarpManagementDemo;

public class YarpManagementDemoWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<YarpManagementDemoWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
