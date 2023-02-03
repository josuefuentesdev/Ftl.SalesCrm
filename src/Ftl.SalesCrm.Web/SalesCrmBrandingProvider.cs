using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Ftl.SalesCrm.Web;

[Dependency(ReplaceServices = true)]
public class SalesCrmBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SalesCrm";
}
