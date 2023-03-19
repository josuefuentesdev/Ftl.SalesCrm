using Ftl.SalesCrm.Lifecyclestages;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ftl.SalesCrm.LeadStatuses
{
    public interface ILeadStatusAppService :
        ICrudAppService<
            LeadStatusDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLeadStatusDto
            >
    {
    }
}
