using AutoMapper;
using Ftl.SalesCrm.Contacts;

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
    }
}
