using AutoMapper;
using Ftl.SalesCrm.Contacts;
using static Ftl.SalesCrm.Web.Pages.Contacts.CreateModalModel;
using static Ftl.SalesCrm.Web.Pages.Contacts.EditModalModel;

namespace Ftl.SalesCrm.Web;

public class SalesCrmWebAutoMapperProfile : Profile
{
    public SalesCrmWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CreateContactViewModel, CreateUpdateContactDto>();
        CreateMap<ContactDto, EditContactViewModel>();
        CreateMap<EditContactViewModel, CreateUpdateContactDto>();
    }
}
