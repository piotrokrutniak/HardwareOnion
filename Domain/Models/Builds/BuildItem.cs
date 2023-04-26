using Domain.Common;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Builds
{
    public class BuildItem : AuditableBaseEntity
    {
        public int BuildId { get; set; }
        public Build Build { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
