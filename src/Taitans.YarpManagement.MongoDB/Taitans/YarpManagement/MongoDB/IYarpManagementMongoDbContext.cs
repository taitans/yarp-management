using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public interface IYarpManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<ProxyConfig> ProxyConfigs { get; }
    }
}
