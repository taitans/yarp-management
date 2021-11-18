using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Taitans.YarpManagement
{
    public class YarpManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IProxyConfigRepository _proxyConfigRepository;

        public YarpManagementDataSeedContributor(
            IGuidGenerator guidGenerator, ICurrentTenant currentTenant,
            IProxyConfigRepository proxyConfigRepository)
        {
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _proxyConfigRepository = proxyConfigRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {
                await _proxyConfigRepository.InsertAsync(new ProxyConfig(YarpManagementTestData.RollBackId, YarpManagementTestData.Name, YarpManagementTestData.RollBackValue, null) { IsDeleted = true });

                await _proxyConfigRepository.InsertAsync(new ProxyConfig(YarpManagementTestData.CurrentId, YarpManagementTestData.Name, YarpManagementTestData.CurrentValue, null));

                await _proxyConfigRepository.InsertAsync(new ProxyConfig(_guidGenerator.Create(), "Loongle2", YarpManagementTestData.CurrentValue, null));
            }
        }
    }
}
