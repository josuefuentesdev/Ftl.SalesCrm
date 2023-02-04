using Ftl.SalesCrm.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ftl.SalesCrm.Web.Pages.Contacts
{
    public class CreateModalModel : SalesCrmPageModel
    {
        [BindProperty]
        public CreateUpdateContactDto Contact { get; set; }
        private readonly IContactAppService _contactService;

        public CreateModalModel(IContactAppService contactService)
        {
            _contactService = contactService;
        }

        public void OnGet()
        {
            Contact = new CreateUpdateContactDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _contactService.CreateAsync(Contact);
            return NoContent();
        }
    }
}
