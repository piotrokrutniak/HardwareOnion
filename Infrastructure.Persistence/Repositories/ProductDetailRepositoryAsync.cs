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
    public class ProductDetailRepositoryAsync : GenericRepositoryAsync<ProductDetail>, IProductDetailRepositoryAsync
    {
        private readonly DbSet<ProductDetail> _productDetails;

        public ProductDetailRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _productDetails = dbContext.Set<ProductDetail>();
        }

        public async Task<IReadOnlyList<ProductDetail>> GetPagedReponseAsync(int pageNumber, int pageSize, int productId)
        {
            return await _productDetails
                .Where(x => x.ProductId == productId)
                .Include(x => x.DetailType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
