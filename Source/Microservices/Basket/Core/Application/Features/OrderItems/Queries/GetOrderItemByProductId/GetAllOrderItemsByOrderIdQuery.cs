using Application.Features.OrderItems.Queries.GetAllOrderItems;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Queries.GetOrderItemsByOrderId
{
    public class GetAllOrderItemsByOrderIdQuery : IRequest<PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int OrderId { get; set; }
    }
    public class GetAllOrderItemsByOrderIdQueryHandler : IRequestHandler<GetAllOrderItemsByOrderIdQuery, PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>>
    {
        private readonly IOrderItemRepositoryAsync _orderItemRepository;
        private readonly IMapper _mapper;
        public GetAllOrderItemsByOrderIdQueryHandler(IOrderItemRepositoryAsync orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>> Handle(GetAllOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllOrderItemsByOrderIdParameter>(request);
            var orderItem = await _orderItemRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize, validFilter.OrderId);
            var orderItemViewModel = _mapper.Map<IEnumerable<GetAllOrderItemsViewModel>>(orderItem);
            return new PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>(orderItemViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
