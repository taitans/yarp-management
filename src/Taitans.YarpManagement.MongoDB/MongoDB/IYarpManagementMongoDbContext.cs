using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public interface IYarpManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
