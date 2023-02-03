using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Ftl.SalesCrm.Pages;

public class Index_Tests : SalesCrmWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
