using Ftl.SalesCrm.Contacts;
using Ftl.SalesCrm.Lifecyclestages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using static Ftl.SalesCrm.Web.Pages.Contacts.CreateModalModel;
using Volo.Abp.ObjectMapping;

namespace Ftl.SalesCrm.Web.Pages.Contacts
{
    public class EditModalModel : SalesCrmPageModel
    {
        [BindProperty]
        public EditContactViewModel Contact { get; set; }

        private readonly IContactAppService _contactAppService;
        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> LifecyclestageList { get; set; }

        private readonly IContactAppService _contactService;
        private readonly ILifecyclestageAppService _lifecyclestageAppService;

        public EditModalModel(IContactAppService contactAppService, IContactAppService contactService, ILifecyclestageAppService lifecyclestageAppService)
        {
            _contactAppService = contactAppService;
            _contactService = contactService;
            _lifecyclestageAppService = lifecyclestageAppService;
        }

        public async Task OnGetAsync(int id)
        {
            var contactDto = await _contactAppService.GetAsync(id);
            Contact = ObjectMapper.Map<ContactDto, EditContactViewModel>(contactDto);

            var LifecyclestageItems = await _lifecyclestageAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            var LifecyclestageItemsOrdered = LifecyclestageItems.Items.OrderBy(x => x.CreationTime);

            LifecyclestageList = LifecyclestageItemsOrdered.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.Name,
            }).ToList();


            var PotentialOwnerUserList = await _contactService.GetPotentialOwnerUserListAsync();
            UserList = new()
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
            var dto = ObjectMapper.Map<EditContactViewModel, CreateUpdateContactDto>(Contact);
            if (!String.IsNullOrEmpty(Contact.OwnerUserName))
            {
                var PotentialOwnerUserList = await _contactService.GetPotentialOwnerUserListAsync();
                var potentialUserId = PotentialOwnerUserList.Where(p => p.UserName == Contact.OwnerUserName).FirstOrDefault()?.Id;
                if (potentialUserId is Guid) dto.OwnerUserId = potentialUserId;
            }
            
            await _contactService.UpdateAsync(
                Contact.Id,
                dto);

            return NoContent();
        }
        public class EditContactViewModel
        {
            [HiddenInput]
            public int Id { get; set; }
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            [Display(Name = "ContactOwner")]
            [SelectItems(nameof(UserList))]
            public string OwnerUserName { get; set; }
            public string Phone { get; set; }
            [Display(Name = "Lifecyclestage")]
            [SelectItems(nameof(LifecyclestageList))]
            public string LifecyclestageId { get; set; }
            // Sales properties
            public string Leadstatus { get; set; }
        }
    }
}
