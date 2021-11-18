using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Taitans.YarpManagement.MongoDB
{
    public static class YarpManagementMongoDbContextExtensions
    {
        public static void ConfigureYarpManagement(
            this IMongoModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));


            builder.Entity<ProxyConfig>(b =>
            {
                b.CollectionName = YarpManagementDbProperties.DbTablePrefix + "ProxyConfigs"; 
            });
        }
    }
}
