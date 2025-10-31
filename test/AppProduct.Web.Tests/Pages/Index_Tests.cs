using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AppProduct.Pages;

[Collection(AppProductTestConsts.CollectionDefinitionName)]
public class Index_Tests : AppProductWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
