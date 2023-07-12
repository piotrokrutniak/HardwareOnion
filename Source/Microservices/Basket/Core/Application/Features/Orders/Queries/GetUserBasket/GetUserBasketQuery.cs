using Application.Enums;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Models.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Features.Orders.Queries.GetUserBasket
{
    public class GetUserBasketQuery : IRequest<Response<Order>>
    {
        public string UserEmail { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetUserBasketQuery, Response<Order>>
        {
            private readonly IOrderRepositoryAsync _orderRepository;
            public GetOrderByIdQueryHandler(IOrderRepositoryAsync orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<Response<Order>> Handle(GetUserBasketQuery query, CancellationToken cancellationToken)
            {
                var order = await GetUserBasket(query);
                    
                return new Response<Order>(order);
            }

            private async Task<Order> GetUserBasket(GetUserBasketQuery query)
            {
                try
                {
                    return await _orderRepository.GetUserBasketAsync(query.UserEmail);
                }
                catch (Exception ex)
                {
                    CreateBasket(query.UserEmail);
                    return await _orderRepository.GetUserBasketAsync(query.UserEmail);
                }
            }

            private async void CreateBasket(string email)
            {
                var basket = new Order { UserEmail = email, OrderStatus = OrderStatus.Basket.ToString() };
                
                await _orderRepository.AddAsync(basket);
            }
        }
    }
}
