using Volo.Abp.Modularity;

namespace AppProduct;

public abstract class AppProductApplicationTestBase<TStartupModule> : AppProductTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
