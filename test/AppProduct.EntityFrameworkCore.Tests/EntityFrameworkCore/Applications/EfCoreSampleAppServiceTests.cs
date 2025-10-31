using AppProduct.Samples;
using Xunit;

namespace AppProduct.EntityFrameworkCore.Applications;

[Collection(AppProductTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AppProductEntityFrameworkCoreTestModule>
{

}
