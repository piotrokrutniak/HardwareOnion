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
    public class ProductDetailRepositoryAsync : GenericRepositoryAsync<ProductDetail>, IProductDetailRepositoryAsync
    {
        private readonly DbSet<ProductDetail> _productDetails;

        public ProductDetailRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _productDetails = dbContext.Set<ProductDetail>();
        }
    }
}
