﻿using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public partial class CreateOrderCommand : IRequest<Response<int>>
    {
        public string OrderStatus { get; set; }
        public string UserEmail { get; set; }
    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<int>>
    {
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IOrderRepositoryAsync orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            await _orderRepository.AddAsync(order);

            return new Response<int>(order.Id);
        }
    }
}
