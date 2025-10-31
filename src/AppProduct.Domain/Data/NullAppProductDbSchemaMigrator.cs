using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AppProduct.Data;

/* This is used if database provider does't define
 * IAppProductDbSchemaMigrator implementation.
 */
public class NullAppProductDbSchemaMigrator : IAppProductDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
