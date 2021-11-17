using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Taitans.YarpManagement.EntityFrameworkCore
{
    [ConnectionStringName(YarpManagementDbProperties.ConnectionStringName)]
    public interface IYarpManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}