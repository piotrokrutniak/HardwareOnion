using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Builds
{
    public class Build : AuditableBaseEntity
    {
        public virtual List<BuildItem> BuildItems { get; set; }
    }
}
