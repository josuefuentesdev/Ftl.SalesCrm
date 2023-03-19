using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Ftl.SalesCrm.Lifecyclestages
{
    public class Lifecyclestage : AuditedEntity<Guid>
    {
        public string Name { get; set; }
    }
}
