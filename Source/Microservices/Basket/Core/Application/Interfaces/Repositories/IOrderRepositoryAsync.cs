using Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IOrderRepositoryAsync : IGenericRepositoryAsync<Order>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<Order>> GetPagedReponseAsync(int pageNumber, int pageSize, string sortBy = "DateDesc");
        int GetMaxPage(int pageSize, int orderCount);
    }
}
