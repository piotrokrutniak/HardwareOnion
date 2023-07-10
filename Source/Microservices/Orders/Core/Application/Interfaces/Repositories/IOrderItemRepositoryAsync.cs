using Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IOrderItemRepositoryAsync : IGenericRepositoryAsync<OrderItem>
    {
        Task<IReadOnlyList<OrderItem>> GetPagedReponseAsync(int pageNumber, int pageSize, int orderId);
    }
}
