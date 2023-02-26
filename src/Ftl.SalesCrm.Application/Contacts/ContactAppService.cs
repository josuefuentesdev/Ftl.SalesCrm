using Ftl.SalesCrm.Permissions;
using Ftl.SalesCrm.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Ftl.SalesCrm.Contacts
{
    public class ContactAppService :
        CrudAppService<
            Contact,
            ContactDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateContactDto>,
        IContactAppService
    {
        protected IIdentityUserRepository UserRepository { get; }

        public ContactAppService(IRepository<Contact, int> repository, IIdentityUserRepository userRepository) : base(repository)
        {
            GetPolicyName = SalesCrmPermissions.Contacts.Default;
            GetListPolicyName = SalesCrmPermissions.Contacts.Default;
            CreatePolicyName = SalesCrmPermissions.Contacts.Create;
            UpdatePolicyName = SalesCrmPermissions.Contacts.Edit;
            DeletePolicyName = SalesCrmPermissions.Contacts.Delete;
            UserRepository = userRepository;
        }

        public async Task<IList<PotentialOwnerUserDto>> GetPotentialOwnerUserListAsync()
        {
            var users = await UserRepository.GetListAsync();

            var usersInfo = ObjectMapper.Map<List<IdentityUser>, List<PotentialOwnerUserDto>>(users);

            return usersInfo;
        }
    }
}
