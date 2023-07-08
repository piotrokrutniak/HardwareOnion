using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersViewModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string OrderStatus { get; set; }
        public int LastPage { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
