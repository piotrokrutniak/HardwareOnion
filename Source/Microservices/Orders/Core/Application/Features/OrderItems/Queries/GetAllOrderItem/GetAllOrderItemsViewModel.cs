using Domain.Models.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.OrderItems.Queries.GetAllOrderItem
{
    public class GetAllOrderItemsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}