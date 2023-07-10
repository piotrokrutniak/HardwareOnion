using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Models.Orders;

namespace Infrastructure.Persistence.Repositiories
{
    public class OrderItemRepositoryAsync : GenericRepositoryAsync<OrderItem>, IOrderItemRepositoryAsync
    {
        private readonly DbSet<OrderItem> _orderItems;

        public OrderItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _orderItems = dbContext.Set<OrderItem>();
        }

        public async Task<IReadOnlyList<OrderItem>> GetPagedReponseAsync(int pageNumber, int pageSize, int orderId)
        {
            return await _orderItems
                .Where(x => x.OrderId == orderId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
