using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Products
{
    public class ProductType : AuditableBaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
