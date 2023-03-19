using Ftl.SalesCrm.Contacts;
using Ftl.SalesCrm.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ftl.SalesCrm.Lifecyclestages
{
    public interface ILifecyclestageAppService :
        ICrudAppService<
            LifecyclestageDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLifecyclestageDto
            >
    {
    }
}
