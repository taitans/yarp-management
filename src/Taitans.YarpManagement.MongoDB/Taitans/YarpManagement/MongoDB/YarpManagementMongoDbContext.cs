using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public class YarpManagementMongoDbContext : AbpMongoDbContext, IYarpManagementMongoDbContext
    {
        public IMongoCollection<ProxyConfig> ProxyConfigs => Collection<ProxyConfig>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureYarpManagement();
        }
    }
}