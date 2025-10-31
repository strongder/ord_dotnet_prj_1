using Volo.Abp.Modularity;

namespace AppProduct;

/* Inherit from this class for your domain layer tests. */
public abstract class AppProductDomainTestBase<TStartupModule> : AppProductTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
