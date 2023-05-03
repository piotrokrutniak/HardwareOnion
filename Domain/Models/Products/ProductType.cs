using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Models.Products
{
    public class ProductType : AuditableBaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}
