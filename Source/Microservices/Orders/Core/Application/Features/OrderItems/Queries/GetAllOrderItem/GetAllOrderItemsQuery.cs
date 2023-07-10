using Application.Features.OrderItems.Queries.GetOrderItemByProductId;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Queries.GetAllOrderItem
{
    public class GetAllOrderItemsQuery : IRequest<PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>>
    {
        private readonly IOrderItemRepositoryAsync _orderItemRepository;
        private readonly IMapper _mapper;
        public GetAllOrderItemsQueryHandler(IOrderItemRepositoryAsync orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllOrderItemsByOrderIdParameter>(request);
            var orderItem = await _orderItemRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var orderItemViewModel = _mapper.Map<IEnumerable<GetAllOrderItemsViewModel>>(orderItem);
            return new PagedResponse<IEnumerable<GetAllOrderItemsViewModel>>(orderItemViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
