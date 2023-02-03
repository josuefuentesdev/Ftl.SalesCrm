using Ftl.SalesCrm.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Ftl.SalesCrm.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SalesCrmEntityFrameworkCoreModule),
    typeof(SalesCrmApplicationContractsModule)
    )]
public class SalesCrmDbMigratorModule : AbpModule
{

}
