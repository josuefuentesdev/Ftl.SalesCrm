using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ftl.SalesCrm.Contacts
{
    public class CreateUpdateContactDto
    {
        // Contact information
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public Guid LifecyclestageId { get; set; }
        [StringLength(50)]
        public string Mobilephone { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        // Sales properties
        public Guid LeadStatusId { get; set; }
        public int Score { get; set; }
        public Guid? OwnerUserId { get; set; }
    }
}
