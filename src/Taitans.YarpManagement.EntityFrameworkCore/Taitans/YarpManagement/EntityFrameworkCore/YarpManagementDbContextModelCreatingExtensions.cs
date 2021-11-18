using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Taitans.YarpManagement.EntityFrameworkCore
{
    public static class YarpManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureYarpManagement(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<ProxyConfig>(b =>
            {
                b.ToTable(YarpManagementDbProperties.DbTablePrefix + "ProxyConfigs",
                    YarpManagementDbProperties.DbSchema);
                 
                b.ConfigureByConvention();

                b.ApplyObjectExtensionMappings();
            });


            builder.TryConfigureObjectExtensions<YarpManagementDbContext>();
        }
    }
}
