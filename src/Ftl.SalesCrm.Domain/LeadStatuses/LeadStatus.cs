using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ftl.SalesCrm.LeadStatuses
{
    public class LeadStatus : AuditedEntity<Guid>
    {
        public string Label { get; set; }
        public string InternalValue { get; set; }
    }
}
