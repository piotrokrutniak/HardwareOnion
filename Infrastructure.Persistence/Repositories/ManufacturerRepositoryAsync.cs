using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Products;
using Domain.Models.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class ManufacturerRepositoryAsync : GenericRepositoryAsync<Manufacturer>, IManufacturerRepositoryAsync
    {
        private readonly DbSet<Manufacturer> _products;

        public ManufacturerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Manufacturer>();
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
