using Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.OrderItems.Queries.GetAllOrderItems
{
    public class GetAllOrderItemsParameter : RequestParameter
    {
        public int Id { get; set; }
    }
}
