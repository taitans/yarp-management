using Taitans.YarpManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Taitans.YarpManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(YarpManagementEntityFrameworkCoreTestModule)
        )]
    public class YarpManagementDomainTestModule : AbpModule
    {
        
    }
}
