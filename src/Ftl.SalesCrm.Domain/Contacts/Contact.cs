using Volo.Abp.Domain.Entities.Auditing;

namespace Ftl.SalesCrm.Contacts
{
    public class Contact : FullAuditedAggregateRoot<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Lifecyclestage { get; set; }
        public string Mobilephone { get; set; }
        public string Phone { get; set; }
    }
}
