using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Orders;
using System.Linq;

namespace Infrastructure.Persistence.Repositiories
{
    public class OrderRepositoryAsync : GenericRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private readonly DbSet<Order> _orders;

        public OrderRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _orders = dbContext.Set<Order>();
            _orders.Include(p => p.OrderItems).ToList();
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
            return await _orders
                        .Include(p => p.OrderItems).AsNoTracking()
                        .FirstAsync(x => x.Id == id);
        }

        public async Task<Order> GetUserBasketAsync(string email)
        {
            return await _orders
                        .Where(x => x.OrderStatus == "Basket")
                        .Include(p => p.OrderItems).AsNoTracking()
                        .FirstAsync(x => x.UserEmail == email);
        }

        public async Task<Order> GetByEmailAsync(string email)
        {
            return await _orders
                        .Include(p => p.OrderItems).AsNoTracking()
                        .FirstAsync(x => x.UserEmail == email);
        }

        public async Task<IReadOnlyList<Order>> GetPagedReponseAsync(int pageNumber, int pageSize, string sortBy = "DateDesc")
        {

            switch (sortBy)
            {
                case "DateAsc":
                    return await GetOrdersDateAsc(pageNumber, pageSize);
                case "DateDesc":
                default:
                    return await GetOrdersDateDesc(pageNumber, pageSize);
            }
        }

        public async Task<int> CountAsync()
        {
            return await _orders.CountAsync();
        }

        public int GetMaxPage(int pageSize, int orderCount)
        {
            double maxPage = Math.Ceiling(orderCount / (float)pageSize);

            return (int)maxPage;
        }

        #region Private Ordered Retrieval Methods

        private async Task<IReadOnlyList<Order>> GetOrdersDateDesc(int pageNumber, int pageSize)
        {
            return await _orders
                .OrderByDescending(p => p.Created)
                .Include(p => p.OrderItems)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        private async Task<IReadOnlyList<Order>> GetOrdersDateAsc(int pageNumber, int pageSize)
        {
            return await _orders
                .OrderBy(p => p.Created)
                .Include(p => p.OrderItems)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion

    }


}
