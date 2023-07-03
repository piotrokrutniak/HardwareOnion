using Application.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultProductTypes
    {
        public static async Task SeedAsync(IProductTypeRepositoryAsync productTypeRepositoryAsync)
        {
            List<ProductType> productTypes = new List<ProductType>
                {
                    new ProductType("GPU"),
                    new ProductType("CPU"),
                    new ProductType("RAM"),
                    new ProductType("Motherboard"),
                    new ProductType("PSU"),
                    new ProductType("Case"),
                    new ProductType("Hard Drive"),
                };

            if (!productTypeRepositoryAsync.GetAllAsync().Result.Any())
            {
                foreach (var productType in productTypes)
                {
                    await productTypeRepositoryAsync.AddAsync(productType);
                }
            }
        }
    }
}
