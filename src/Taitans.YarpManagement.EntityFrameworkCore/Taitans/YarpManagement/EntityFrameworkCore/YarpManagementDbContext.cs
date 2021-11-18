using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.YarpManagement.EntityFrameworkCore
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public class YarpManagementDbContext : AbpDbContext<YarpManagementDbContext>, IYarpManagementDbContext
    {
        public DbSet<ProxyConfig> ProxyConfigs { get; set; }

        public YarpManagementDbContext(DbContextOptions<YarpManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureYarpManagement();
        }
    }
}