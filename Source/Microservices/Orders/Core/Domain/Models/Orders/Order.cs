using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Orders
{
    public class Order : AuditableBaseEntity
    {
        public Order() { }
        public string OrderStatus { get; set; }
        public string UserEmail { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
