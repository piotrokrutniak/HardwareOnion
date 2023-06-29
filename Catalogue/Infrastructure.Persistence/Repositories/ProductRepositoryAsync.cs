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

        public async Task<IReadOnlyList<Product>> GetPagedReponseAsync(int pageNumber, int pageSize, string sortBy = "DateDesc")
        {

            switch (sortBy)
            {
                case "PriceAsc":
                    return await GetProductsPriceAsc(pageNumber, pageSize);
                case "PriceDesc":
                    return await GetProductsPriceDesc(pageNumber, pageSize);
                case "DateAsc":
                    return await GetProductsDateAsc(pageNumber, pageSize);
                case "DateDesc":
                default:
                    return await GetProductsDateDesc(pageNumber, pageSize);
            }
        }

        public async Task<int> CountAsync()
        {
            return await _products.CountAsync();
        }

        public int GetMaxPage(int pageSize, int productCount)
        {
            double maxPage = Math.Ceiling((float)productCount / (float)pageSize);

            return (int)maxPage;
        }

        #region Private Ordered Retrieval Methods

        private async Task<IReadOnlyList<Product>> GetProductsDateDesc(int pageNumber, int pageSize)
        {
            return await _products
                .OrderByDescending(p => p.Created)
                .Include(p => p.Manufacturer)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task<IReadOnlyList<Product>> GetProductsDateAsc(int pageNumber, int pageSize)
        {
            return await _products
                .OrderBy(p => p.Created)
                .Include(p => p.Manufacturer)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task<IReadOnlyList<Product>> GetProductsPriceDesc(int pageNumber, int pageSize)
        {
            return await _products
                .OrderByDescending(p => p.Price)
                .Include(p => p.Manufacturer)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task<IReadOnlyList<Product>> GetProductsPriceAsc(int pageNumber, int pageSize)
        {
            return await _products
                .OrderBy(p => p.Price)
                .Include(p => p.Manufacturer)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion

    }


}
