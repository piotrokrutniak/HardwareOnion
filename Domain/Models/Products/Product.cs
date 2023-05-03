using Domain.Common;
using Domain.Models.Entities;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.Models.Products
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductTypeId { get; set; }
        public int ManufacturerId { get; set; }
        [JsonIgnore]
        public ProductType ProductType { get; set; }
        [JsonIgnore]
        public Manufacturer Manufacturer { get; set; }
        [JsonIgnore]
        public List<ProductDetail> Details { get; set; }
    }
}
