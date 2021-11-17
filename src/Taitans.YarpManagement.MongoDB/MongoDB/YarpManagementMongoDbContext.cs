using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public class YarpManagementMongoDbContext : AbpMongoDbContext, IYarpManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureYarpManagement();
        }
    }
}