using Ftl.SalesCrm.Lifecyclestages;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ftl.SalesCrm.Contacts
{
    public class Contact : FullAuditedAggregateRoot<int>
    {
        // Contact information
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        
        public Guid LifecyclestageId { get; set; }

        public string Mobilephone { get; set; }
        public string Phone { get; set; }

        // Sales properties
        public Guid LeadstatusId { get; set; }
        public int Score { get; set; }
        public Guid? OwnerUserId { get; set; }
        public DateTime? OwnerAssigneddate { get; set; }
    }
}
