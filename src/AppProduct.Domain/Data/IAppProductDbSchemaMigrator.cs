using System.Threading.Tasks;

namespace AppProduct.Data;

public interface IAppProductDbSchemaMigrator
{
    Task MigrateAsync();
}
