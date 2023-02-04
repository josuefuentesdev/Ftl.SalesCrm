using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Ftl.SalesCrm.Contacts
{
    public class ContactDto : FullAuditedEntityDto<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Lifecyclestage { get; set; }
        public string Mobilephone { get; set; }
        public string Phone { get; set; }
    }
}
