using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Taitans.YarpManagementDemo.Pages;

public class Index_Tests : YarpManagementDemoWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
