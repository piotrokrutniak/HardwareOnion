using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Products;

namespace Application.DTOs.Order
{
    public class ProductBundle
    {
        public ProductBundle(List<Product> products)
        {
            foreach (var product in products)
            {
                OrderItems.Add(new ProductData { Price = product.Price, ProductName = product.Name });
                Total =+ product.Price;
            }

            PurchaseTime = DateTime.Now;
        }

        List<ProductData> OrderItems = new List<ProductData>();
        public decimal Total { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
