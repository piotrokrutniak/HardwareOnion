using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Products;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> _products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<Product>();
            _products.Include(p => p.Details)
                     .Include(p => p.Manufacturer).ToList();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _products
                        .Include(p => p.Details)
                        .Include(m => m.Manufacturer).AsNoTracking()
                        .FirstAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            int count = await _products.CountAsync();
            int maxPage = GetMaxPage(pageSize, count);

            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }

            return await _products
                .Include(p => p.Manufacturer)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        private int GetMaxPage(int pageSize, int productCount)
        {
            double maxPage = Math.Ceiling((float)productCount / (float)pageSize);

            return (int)maxPage;
        }
    }

    
}
