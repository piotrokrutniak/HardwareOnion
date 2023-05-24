using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<Product>> GetPagedReponseAsync(int pageNumber, int pageSize, string sortBy = "DateDesc");
        int GetMaxPage(int pageSize, int productCount);
    }
}
