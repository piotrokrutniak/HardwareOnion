using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Commands.CreateOrderItem
{
    public partial class CreateOrderItemCommand : IRequest<Response<int>>
    {
        public int OrderItemId { get; set; }
        public string OrderName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, Response<int>>
        {
            private readonly IOrderItemRepositoryAsync _orderItemRepository;
            private readonly IMapper _mapper;
            public CreateOrderItemCommandHandler(IOrderItemRepositoryAsync orderItemRepository, IMapper mapper)
            {
                _orderItemRepository = orderItemRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
            {
                var orderItem = _mapper.Map<OrderItem>(request);
                await _orderItemRepository.AddAsync(orderItem);
                return new Response<int>(orderItem.Id);
            }
        }
    }
}
