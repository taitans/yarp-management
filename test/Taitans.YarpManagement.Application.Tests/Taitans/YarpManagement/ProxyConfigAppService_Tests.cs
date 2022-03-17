using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Uow;
using Xunit;

namespace Taitans.YarpManagement
{
    public class ProxyConfigAppService_Tests : YarpManagementApplicationTestBase
    {
        private readonly IProxyConfigAppService _proxyConfigAppService;
        private readonly IProxyConfigRepository _proxyConfigRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataFilter _dataFilter;

        public ProxyConfigAppService_Tests()
        {
            _proxyConfigAppService = GetRequiredService<IProxyConfigAppService>();
            _proxyConfigRepository = GetRequiredService<IProxyConfigRepository>();
            _unitOfWork = GetRequiredService<IUnitOfWork>();
            _dataFilter = GetRequiredService<IDataFilter>();
        }

        [Fact]
        public async Task CreateAsync()
        {
            var entity = await _proxyConfigRepository.GetAsync(x => x.Name == "Loongle");
            entity.Value.ShouldBe(YarpManagementTestData.CurrentValue);

            await _proxyConfigAppService.CreateAsync(new Dtos.CreateProxyConfigDto { Name = YarpManagementTestData.Name, Value = "Very Good" });

            await _unitOfWork.CompleteAsync();

            entity = await _proxyConfigRepository.GetAsync(x => x.Name == "Loongle");
            entity.Value.ShouldBe("Very Good");
            entity.Version.ShouldBe("00003");
        }

        [Fact]
        public async Task GetHistoryListAsync()
        {
            var historys = await _proxyConfigAppService.GetHistoryListAsync(new Dtos.GetHistoryInput { Name = YarpManagementTestData.Name });
            historys.Items.Count.ShouldBe(2);
            historys.Items.ShouldContain(x => x.IsCurrent && x.Value == YarpManagementTestData.CurrentValue);
            historys.Items.ShouldContain(x => !x.IsCurrent && x.Value == YarpManagementTestData.RollBackValue);
        }

        [Fact]
        public async Task RollBackAsync()
        {
            await _proxyConfigAppService.RollBackAsync(YarpManagementTestData.RollBackId);

            var list = await _proxyConfigRepository.GetListByNameAsync(YarpManagementTestData.Name);
            list.Count.ShouldBe(1);
            list.ShouldNotContain(x => x.Name == YarpManagementTestData.CurrentValue);
        }
    }
}
