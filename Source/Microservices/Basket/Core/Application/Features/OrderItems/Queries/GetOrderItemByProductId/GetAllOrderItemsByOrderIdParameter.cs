using Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.OrderItems.Queries.GetAllOrderItems
{
    public class GetAllOrderItemsByOrderIdParameter : RequestParameter
    {
        public int OrderId { get; set; }
    }
}
