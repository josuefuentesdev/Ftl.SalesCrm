using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Ftl.SalesCrm.Data;

/* This is used if database provider does't define
 * ISalesCrmDbSchemaMigrator implementation.
 */
public class NullSalesCrmDbSchemaMigrator : ISalesCrmDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
