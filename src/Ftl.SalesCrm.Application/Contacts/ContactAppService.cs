using Ftl.SalesCrm.LeadStatuses;
using Ftl.SalesCrm.Lifecyclestages;
using Ftl.SalesCrm.Permissions;
using Ftl.SalesCrm.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Users;

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
        private readonly IRepository<Lifecyclestage, Guid> _lifecyclestageRepository;
        private readonly IRepository<LeadStatus, Guid> _leadstatusRepository;

        public ContactAppService(
            IRepository<Contact, int> repository,
            IIdentityUserRepository userRepository,
            IRepository<Lifecyclestage, Guid> lifecyclestageRepository
,
            IRepository<LeadStatus, Guid> leadstatusRepository)
            : base(repository)
        {
            GetPolicyName = SalesCrmPermissions.Contacts.Default;
            GetListPolicyName = SalesCrmPermissions.Contacts.Default;
            CreatePolicyName = SalesCrmPermissions.Contacts.Create;
            UpdatePolicyName = SalesCrmPermissions.Contacts.Edit;
            DeletePolicyName = SalesCrmPermissions.Contacts.Delete;
            UserRepository = userRepository;
            _lifecyclestageRepository = lifecyclestageRepository;
            _leadstatusRepository = leadstatusRepository;
        }

        public async Task<IList<PotentialOwnerUserDto>> GetPotentialOwnerUserListAsync()
        {
            var users = await UserRepository.GetListAsync();

            var usersInfo = ObjectMapper.Map<List<IdentityUser>, List<PotentialOwnerUserDto>>(users);

            return usersInfo;
        }

        public override async Task<PagedResultDto<ContactDto>>
            GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Contact> from the default repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join contacts and authors
            var query = from contact in queryable
                        join lifecyclestage in await _lifecyclestageRepository.GetQueryableAsync() on contact.LifecyclestageId equals lifecyclestage.Id
                        join leadstatus in await _leadstatusRepository.GetQueryableAsync() on contact.LeadstatusId equals leadstatus.Id
                        select new { contact, lifecyclestage, leadstatus };

            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of ContactDto objects
            var contactDtos = queryResult.Select(x =>
            {
                var contactDto = ObjectMapper.Map<Contact, ContactDto>(x.contact);
                contactDto.LifecyclestageName = x.lifecyclestage.Name;
                contactDto.LeadstatusLabel = x.leadstatus.Label;
                return contactDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            // Get the OwnerUserName from the identity UserName
            var users = await UserRepository.GetListAsync();
            foreach (var contactDto in contactDtos)
            {
                var user = users.FirstOrDefault(x => x.Id == contactDto.OwnerUserId);
                if (user != null)
                {
                    contactDto.OwnerUserName = user.UserName;
                }
            }

            return new PagedResultDto<ContactDto>(
                totalCount,
                contactDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"contact.{nameof(Contact.Firstname)}";
            }

            if (sorting.Contains("lifecyclestageName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "lifecyclestageName",
                    "lifecyclestage.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"contact.{sorting}";
        }
    }
}
