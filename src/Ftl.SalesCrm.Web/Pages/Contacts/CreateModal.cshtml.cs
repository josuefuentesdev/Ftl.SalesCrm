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
using System.ComponentModel.DataAnnotations;

namespace Ftl.SalesCrm.Web.Pages.Contacts
{
    public class CreateModalModel : SalesCrmPageModel
    {
        [BindProperty]
        public CreateContactViewModel Contact { get; set; }

        public List<SelectListItem> UserList { get; set; }
        public IList<PotentialOwnerUserDto> PotentialOwnerUserList { get; set; }

        private readonly IContactAppService _contactService;

        public CreateModalModel(IContactAppService contactService)
        {
            _contactService = contactService;
        }

        public async void OnGet()
        {
            PotentialOwnerUserList = await _contactService.GetPotentialOwnerUserListAsync();

            UserList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",
                    Text = L["NoOwner"]
                }
            };
            UserList.AddRange(PotentialOwnerUserList.Select(u => new SelectListItem()
            {
                Value = u.UserName,
                Text = u.Name,
            }).ToList());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateContactViewModel, CreateUpdateContactDto>(Contact);
            if (!String.IsNullOrEmpty(Contact.OwnerUserName))
            {
                var potentialUserId = PotentialOwnerUserList.Where(p => p.UserName == Contact.OwnerUserName).FirstOrDefault()?.Id;
                if (potentialUserId is Guid) dto.OwnerUserId = potentialUserId;
            }
            await _contactService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateContactViewModel
        {
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            [Display(Name = "ContactOwner")]
            [SelectItems(nameof(UserList))]
            public string OwnerUserName { get; set; }
            public string Phone { get; set; }
            public string Lifecyclestage { get; set; }
            // Sales properties
            public string Leadstatus { get; set; }
        }
    }
}
