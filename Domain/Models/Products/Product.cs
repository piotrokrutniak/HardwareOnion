using Domain.Models.Entities;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Common;

namespace Domain.Models.Products
{
    public class Product : AuditableBaseEntity
    {
        public Product()
        {
            Details = new List<ProductDetail>();
        }

        public Product(string name, string description, decimal price, int quantity, int productTypeId, int manufacturerId)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            ProductTypeId = productTypeId;
            ManufacturerId = manufacturerId;
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
