using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Taitans.YarpManagement
{
    public abstract class ProxyConfigRepository_Tests<TStartupModule> :
        YarpManagementTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        public IProxyConfigRepository ProxyConfigRepository { get; }

        public ProxyConfigRepository_Tests()
        {
            ProxyConfigRepository = GetRequiredService<IProxyConfigRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            var proxyConfigs = await ProxyConfigRepository.GetListAsync();
            proxyConfigs.Count.ShouldBe(2);
            proxyConfigs.ShouldContain(x => x.Name == YarpManagementTestData.Name);
            proxyConfigs.ShouldContain(x => x.Name == "Loongle2");
        }

        [Fact]
        public async Task GetListByNameAsync()
        {
            var entitiy = await ProxyConfigRepository.GetListByNameAsync(YarpManagementTestData.Name);
            entitiy.ShouldNotBeNull();
            entitiy.ShouldContain(x => x.Value == "Good");
        }
    }
}
