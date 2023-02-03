using Volo.Abp.Modularity;

namespace Ftl.SalesCrm;

[DependsOn(
    typeof(SalesCrmApplicationModule),
    typeof(SalesCrmDomainTestModule)
    )]
public class SalesCrmApplicationTestModule : AbpModule
{

}
