using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Models.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Queries.GetOrderItemById
{
    public class GetOrderItemByIdQuery : IRequest<Response<OrderItem>>
    {
        public int Id { get; set; }
        public class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, Response<OrderItem>>
        {
            private readonly IOrderItemRepositoryAsync _orderItemRepository;
            public GetOrderItemByIdQueryHandler(IOrderItemRepositoryAsync orderItemRepository)
            {
                _orderItemRepository = orderItemRepository;
            }
            public async Task<Response<OrderItem>> Handle(GetOrderItemByIdQuery query, CancellationToken cancellationToken)
            {
                var orderItem = await _orderItemRepository.GetByIdAsync(query.Id);
                if (orderItem == null) throw new ApiException($"Order Detail Not Found.");
                return new Response<OrderItem>(orderItem);
            }
        }
    }
}
