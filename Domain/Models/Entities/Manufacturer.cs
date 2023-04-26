using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Manufacturer : AuditableBaseEntity
    {
        public string Name { get; set; }
    }
}
