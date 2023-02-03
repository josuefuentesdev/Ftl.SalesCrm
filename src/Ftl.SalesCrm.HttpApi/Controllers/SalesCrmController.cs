using Ftl.SalesCrm.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Ftl.SalesCrm.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SalesCrmController : AbpControllerBase
{
    protected SalesCrmController()
    {
        LocalizationResource = typeof(SalesCrmResource);
    }
}
