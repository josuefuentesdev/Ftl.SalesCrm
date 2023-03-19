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
using Ftl.SalesCrm.Lifecyclestages;
using Volo.Abp.Application.Dtos;
using Ftl.SalesCrm.LeadStatuses;

namespace Ftl.SalesCrm.Web.Pages.Contacts
{
    public class CreateModalModel : SalesCrmPageModel
    {
        [BindProperty]
        public CreateContactViewModel Contact { get; set; }

        public List<SelectListItem> UserList { get; set; }
        public List<SelectListItem> LifecyclestageList { get; set; }
        public List<SelectListItem> LeadStatusList { get; set; }

        private readonly IContactAppService _contactService;
        private readonly ILifecyclestageAppService _lifecyclestageAppService;
        private readonly ILeadStatusAppService _leadStatusAppService;
        public CreateModalModel(IContactAppService contactService, ILifecyclestageAppService lifecyclestageAppService, ILeadStatusAppService leadStatusAppService)
        {
            _contactService = contactService;
            _lifecyclestageAppService = lifecyclestageAppService;
            _leadStatusAppService = leadStatusAppService;
        }

        public async Task OnGet()
        {
            var LifecyclestageItems = (await _lifecyclestageAppService.GetListAsync(new PagedAndSortedResultRequestDto()))
                .Items.OrderBy(x => x.CreationTime);

            LifecyclestageList = LifecyclestageItems.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.Name,
            }).ToList();

            var LeadstatusItems = (await _leadStatusAppService.GetListAsync(new PagedAndSortedResultRequestDto()))
                .Items.OrderBy(x => x.CreationTime);
            LeadStatusList = LeadstatusItems.Select(u => new SelectListItem()
            {
                Value = u.Id.ToString(),
                Text = u.Label,
            }).ToList();

            var PotentialOwnerUserList = (await _contactService.GetPotentialOwnerUserListAsync());
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
            var dto = ObjectMapper.Map<CreateContactViewModel, CreateUpdateContactDto>(Contact);
            if (!String.IsNullOrEmpty(Contact.OwnerUserName))
            {
                var PotentialOwnerUserList = await _contactService.GetPotentialOwnerUserListAsync();
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
            [Display(Name = "Lifecyclestage")]
            [SelectItems(nameof(LifecyclestageList))]
            public string LifecyclestageId { get; set; }
            // Sales properties
            [Display(Name = "LeadStatus")]
            [SelectItems(nameof(LeadStatusList))]
            public string LeadStatusId { get; set; }
        }
    }
}
