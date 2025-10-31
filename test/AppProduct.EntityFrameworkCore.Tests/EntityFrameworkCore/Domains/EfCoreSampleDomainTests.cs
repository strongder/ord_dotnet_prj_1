using AppProduct.Samples;
using Xunit;

namespace AppProduct.EntityFrameworkCore.Domains;

[Collection(AppProductTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AppProductEntityFrameworkCoreTestModule>
{

}
