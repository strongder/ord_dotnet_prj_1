using AppProduct.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AppProduct.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AppProductEntityFrameworkCoreModule),
    typeof(AppProductApplicationContractsModule)
)]
public class AppProductDbMigratorModule : AbpModule
{
}
