using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Builds
{
    public class Build : AuditableBaseEntity
    {
        public List<BuildItem> BuildItems { get; set; }
    }
}
