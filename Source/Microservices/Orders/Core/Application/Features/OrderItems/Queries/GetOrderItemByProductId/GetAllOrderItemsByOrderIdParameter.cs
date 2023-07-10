using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.OrderItems.Queries.GetOrderItemByProductId
{
    public class GetAllOrderItemsByOrderIdParameter : RequestParameter
    {
        public int OrderId { get; set; }
    }
}
