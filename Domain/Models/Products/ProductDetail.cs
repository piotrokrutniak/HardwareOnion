using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Products
{
    public class ProductDetail : AuditableBaseEntity
    {
        public int DetailTypeId { get; set; }
        public string DetailType { get; set; }
        public string Description { get; set; }
    }
}
