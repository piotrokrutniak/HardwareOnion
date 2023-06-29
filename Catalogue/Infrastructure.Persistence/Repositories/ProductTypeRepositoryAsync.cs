using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Products;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductTypeRepositoryAsync : GenericRepositoryAsync<ProductType>, IProductTypeRepositoryAsync
    {
        private readonly DbSet<ProductType> _products;

        public ProductTypeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<ProductType>();
        }
        /*
        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _products
                .AllAsync(p => p.Barcode != barcode);
        }
        */
    }
}
