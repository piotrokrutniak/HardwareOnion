using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Orders
{
    public class Order : AuditableBaseEntity
    {
        public string OrderStatus { get; set; }
        public string UserEmail { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
