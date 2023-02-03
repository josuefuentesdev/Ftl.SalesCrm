using Ftl.SalesCrm.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ftl.SalesCrm.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SalesCrmPageModel : AbpPageModel
{
    protected SalesCrmPageModel()
    {
        LocalizationResourceType = typeof(SalesCrmResource);
    }
}
