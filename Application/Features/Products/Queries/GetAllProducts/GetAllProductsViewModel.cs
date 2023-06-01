using Domain.Models.Entities;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public int LastPage { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public DateTime Created { get; set; }
    }
}
