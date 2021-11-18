using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.YarpManagement.EntityFrameworkCore
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public interface IYarpManagementDbContext : IEfCoreDbContext
    {
        DbSet<ProxyConfig> ProxyConfigs { get; }
    }
}