using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taitans.YarpManagementDemo.Data;
using Volo.Abp.DependencyInjection;

namespace Taitans.YarpManagementDemo.EntityFrameworkCore;

public class EntityFrameworkCoreYarpManagementDemoDbSchemaMigrator
    : IYarpManagementDemoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreYarpManagementDemoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the YarpManagementDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<YarpManagementDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
