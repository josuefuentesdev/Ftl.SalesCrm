using Ftl.SalesCrm.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Ftl.SalesCrm.Lifecyclestages
{
    public class LifecyclestageAppService :
        CrudAppService<
            Lifecyclestage,
            LifecyclestageDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLifecyclestageDto>,
        ILifecyclestageAppService
    {
        public LifecyclestageAppService(IRepository<Lifecyclestage, Guid> repository)
            : base(repository)
        {

        }
    }
}
