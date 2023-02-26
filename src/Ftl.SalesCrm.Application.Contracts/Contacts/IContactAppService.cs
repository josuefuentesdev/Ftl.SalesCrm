using Ftl.SalesCrm.UserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ftl.SalesCrm.Contacts
{
    public interface IContactAppService :
        ICrudAppService<
            ContactDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateContactDto
            >
    {
        Task<IList<PotentialOwnerUserDto>> GetPotentialOwnerUserListAsync();
    }
}
