using Xunit;

namespace AppProduct.EntityFrameworkCore;

[CollectionDefinition(AppProductTestConsts.CollectionDefinitionName)]
public class AppProductEntityFrameworkCoreCollection : ICollectionFixture<AppProductEntityFrameworkCoreFixture>
{

}
