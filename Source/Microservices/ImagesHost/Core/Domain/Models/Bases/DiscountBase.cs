using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Bases
{
    public abstract class DiscountBase : AuditableBaseEntity
    {
        public int DiscountAmount { get; set; }
        public DateTime Activation { get; set; }
        public DateTime Expiry { get; set; }
    }
}
