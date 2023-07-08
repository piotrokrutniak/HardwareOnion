using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.OrderItems.Queries.GetAllOrderItem
{
    public class GetAllOrderItemsParameter : RequestParameter
    {
        public int Id { get; set; }
    }
}
