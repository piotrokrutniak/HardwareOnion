using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using AutoMapper;
using Domain.Models.Orders;
using Application.Features.OrderItems.Commands.CreateOrderItem;
using Application.Features.OrderItems.Queries.GetAllOrderItem;
using Application.Features.OrderItems.Queries.GetOrderItemByProductId;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Order, GetAllOrdersViewModel>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<GetAllOrdersQuery, GetAllOrdersParameter>();  

            CreateMap<OrderItem, GetAllOrderItemsViewModel>().ReverseMap();
            CreateMap<CreateOrderItemCommand, OrderItem>();
            CreateMap<GetAllOrderItemsQuery, GetAllOrderItemsParameter>();
            CreateMap<GetAllOrderItemsByOrderIdQuery, GetAllOrderItemsByOrderIdParameter>();
        }
    }
}
