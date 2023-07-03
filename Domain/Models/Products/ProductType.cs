using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Models.Products
{
    public class ProductType : AuditableBaseEntity
    {
        public ProductType()
        {
            Products = new List<Product>();
        }

        public ProductType(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
