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
        public Product()
        {
            Details = new List<ProductDetail>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual IEnumerable<ProductDetail> Details { get; set; }
    }
}
