using Ftl.SalesCrm.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ftl.SalesCrm.LeadStatuses
{
    public class LeadStatusAppService :
        CrudAppService<
            LeadStatus,
            LeadStatusDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLeadStatusDto>,
        ILeadStatusAppService
    {
        public LeadStatusAppService(
            IRepository<LeadStatus, Guid> repository)
            : base(repository)
        {
        }
    }
}
