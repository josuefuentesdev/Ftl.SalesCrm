using System;
using System.Collections.Generic;
using System.Text;
using Ftl.SalesCrm.Localization;
using Volo.Abp.Application.Services;

namespace Ftl.SalesCrm;

/* Inherit your application services from this class.
 */
public abstract class SalesCrmAppService : ApplicationService
{
    protected SalesCrmAppService()
    {
        LocalizationResource = typeof(SalesCrmResource);
    }
}
