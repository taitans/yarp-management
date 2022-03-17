using System.Threading.Tasks;

namespace Taitans.YarpManagementDemo.Data;

public interface IYarpManagementDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
