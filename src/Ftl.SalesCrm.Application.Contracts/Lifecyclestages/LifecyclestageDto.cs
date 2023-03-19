using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Ftl.SalesCrm.Lifecyclestages
{
    public class LifecyclestageDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
