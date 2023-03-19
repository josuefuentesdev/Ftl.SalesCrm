using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Ftl.SalesCrm.LeadStatuses
{
    public class LeadStatusDto : AuditedEntityDto<Guid>
    {
        public string Label { get; set; }
        public string InternalValue { get; set; }
    }
}
