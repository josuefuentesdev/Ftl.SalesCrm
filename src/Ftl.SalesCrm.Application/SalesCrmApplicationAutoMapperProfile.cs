using AutoMapper;
using Ftl.SalesCrm.Contacts;
using Ftl.SalesCrm.LeadStatuses;
using Ftl.SalesCrm.Lifecyclestages;
using Ftl.SalesCrm.UserInfo;
using Volo.Abp.Identity;

namespace Ftl.SalesCrm;

public class SalesCrmApplicationAutoMapperProfile : Profile
{
    public SalesCrmApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateUpdateContactDto, Contact>();
        CreateMap<ContactDto, CreateUpdateContactDto>();
        CreateMap<IdentityUser, PotentialOwnerUserDto>();

        CreateMap<Lifecyclestage, LifecyclestageDto>();
        CreateMap<CreateUpdateLifecyclestageDto, Lifecyclestage>();

        CreateMap<LeadStatus, LeadStatusDto>();
        CreateMap<CreateUpdateLeadStatusDto, LeadStatus>();

    }
}
