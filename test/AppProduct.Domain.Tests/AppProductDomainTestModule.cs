using Volo.Abp.Modularity;

namespace AppProduct;

[DependsOn(
    typeof(AppProductDomainModule),
    typeof(AppProductTestBaseModule)
)]
public class AppProductDomainTestModule : AbpModule
{

}
