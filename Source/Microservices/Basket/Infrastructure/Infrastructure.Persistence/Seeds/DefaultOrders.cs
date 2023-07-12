using Application.Enums;
using Application.Features.Orders.Queries.GetUserBasket;
using Application.Interfaces.Repositories;
using Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seeds
{
    public class DefaultOrders
    {
        public static async Task SeedAsync(IOrderRepositoryAsync orderRepositoryAsync)
        {
            List<string> users = new List<string>
            {
                "superadmin@gmail.com",
                "guest@gmail.com",
                "user@gmail.com"
            };

            foreach (string email in users)
            {
                await orderRepositoryAsync.AddAsync(new Order { UserEmail = email, OrderStatus = OrderStatus.Basket.ToString() });
            }
        }
    }
}
