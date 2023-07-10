using Domain.Models.Common;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Builds
{
    public class BuildItem : AuditableBaseEntity
    {
        public int BuildId { get; set; }
        public virtual Build Build { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
