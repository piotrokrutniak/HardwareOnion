using Domain.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Discounts
{
    public class ProductDiscount : DiscountBase
    {
        public int TargetId { get; set; }
        public string DiscountTarget { get; set; }
    }
}
