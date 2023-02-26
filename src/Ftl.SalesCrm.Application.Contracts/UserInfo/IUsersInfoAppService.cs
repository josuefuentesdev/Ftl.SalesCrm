using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ftl.SalesCrm.UserInfo
{
    public interface IUsersInfoAppService
    {
        Task<IList<PotentialOwnerUserDto>> GetListAsync();
    }
}
