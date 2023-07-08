using MediatR;

using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Commands.UpdateOrderItem

{
    public class UpdateOrderItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, Response<int>>
        {
            private readonly IOrderItemRepositoryAsync _orderItemRepository;
            public UpdateOrderItemCommandHandler(IOrderItemRepositoryAsync orderItemRepository)
            {
                _orderItemRepository = orderItemRepository;
            }
            public async Task<Response<int>> Handle(UpdateOrderItemCommand command, CancellationToken cancellationToken)
            {
                var orderItem = await _orderItemRepository.GetByIdAsync(command.Id);

                if (orderItem == null)
                {
                    throw new ApiException($"Order Detail Not Found.");
                }
                else
                {
                    orderItem.OrderId = command.OrderId;
                    orderItem.ProductName = command.ProductName;
                    orderItem.Quantity = command.Quantity;
                    orderItem.Price = command.Price;
                    await _orderItemRepository.UpdateAsync(orderItem);
                    return new Response<int>(orderItem.Id);
                }
            }
        }
    }
}
