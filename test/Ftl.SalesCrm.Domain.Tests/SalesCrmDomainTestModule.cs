using Ftl.SalesCrm.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Ftl.SalesCrm;

[DependsOn(
    typeof(SalesCrmEntityFrameworkCoreTestModule)
    )]
public class SalesCrmDomainTestModule : AbpModule
{

}
