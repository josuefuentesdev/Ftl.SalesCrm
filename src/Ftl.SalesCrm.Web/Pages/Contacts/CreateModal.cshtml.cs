using Ftl.SalesCrm.Contacts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Identity;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Ftl.SalesCrm.UserInfo;
using System.Linq;

namespace Ftl.SalesCrm.Web.Pages.Contacts
{
    public class CreateModalModel : SalesCrmPageModel
    {
        [BindProperty]
        public CreateContactViewModel Contact { get; set; }

        public List<SelectListItem> UserList { get; set; }

        private readonly IContactAppService _contactService;

        public CreateModalModel(IContactAppService contactService)
        {
            _contactService = contactService;
        }

        public async void OnGet()
        {
            var potentialOwnerUsers = await _contactService.GetPotentialOwnerUserListAsync();

            UserList = potentialOwnerUsers.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.Name,
            }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateContactViewModel, CreateUpdateContactDto>(Contact);
            await _contactService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateContactViewModel
        {
            public string Email { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            [SelectItems(nameof(UserList))]
            public string UserName { get; set; }
            public string Phone { get; set; }
            public string Lifecyclestage { get; set; }
            // Sales properties
            public string Leadstatus { get; set; }
        }
    }
}
