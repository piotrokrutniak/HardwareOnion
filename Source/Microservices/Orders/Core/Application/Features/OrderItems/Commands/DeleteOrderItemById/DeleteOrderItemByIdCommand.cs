using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Commands.DeleteOrderItemById
{
    public class DeleteOrderItemByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteDetailTypeByIdCommandHandler : IRequestHandler<DeleteOrderItemByIdCommand, Response<int>>
        {
            private readonly IOrderItemRepositoryAsync _orderItemRepository;
            public DeleteDetailTypeByIdCommandHandler(IOrderItemRepositoryAsync orderItemRepository)
            {
                _orderItemRepository = orderItemRepository;
            }
            public async Task<Response<int>> Handle(DeleteOrderItemByIdCommand command, CancellationToken cancellationToken)
            {
                var orderItem = await _orderItemRepository.GetByIdAsync(command.Id);
                if (orderItem == null) throw new ApiException($"Order Item Not Found.");
                await _orderItemRepository.DeleteAsync(orderItem);
                return new Response<int>(orderItem.Id);
            }
        }
    }
}
