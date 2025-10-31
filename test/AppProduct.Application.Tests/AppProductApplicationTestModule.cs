using Volo.Abp.Modularity;

namespace AppProduct;

[DependsOn(
    typeof(AppProductApplicationModule),
    typeof(AppProductDomainTestModule)
)]
public class AppProductApplicationTestModule : AbpModule
{

}
