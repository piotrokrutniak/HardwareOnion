using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<int>>
        {
            private readonly IOrderRepositoryAsync _orderRepository;
            public UpdateOrderCommandHandler(IOrderRepositoryAsync orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<Response<int>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = await _orderRepository.GetByIdAsync(command.Id);

                if (order == null)
                {
                    throw new ApiException($"Order Not Found.");
                }
                else
                {
                    order.UserEmail = command.Name;
                    order.OrderStatus = command.Description;

                    await _orderRepository.UpdateAsync(order);
                    return new Response<int>(order.Id);
                }
            }
        }
    }
}
