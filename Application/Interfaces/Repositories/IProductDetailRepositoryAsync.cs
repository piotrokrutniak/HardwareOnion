using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IProductDetailRepositoryAsync : IGenericRepositoryAsync<ProductDetail>
    {
        Task<IReadOnlyList<ProductDetail>> GetPagedReponseAsync(int pageNumber, int pageSize, int productId);
    }
}
