using System.Threading.Tasks;

namespace Ftl.SalesCrm.Data;

public interface ISalesCrmDbSchemaMigrator
{
    Task MigrateAsync();
}
