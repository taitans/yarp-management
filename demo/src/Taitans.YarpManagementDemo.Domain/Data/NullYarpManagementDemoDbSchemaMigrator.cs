using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Taitans.YarpManagementDemo.Data;

/* This is used if database provider does't define
 * IYarpManagementDemoDbSchemaMigrator implementation.
 */
public class NullYarpManagementDemoDbSchemaMigrator : IYarpManagementDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
