using Domain.Models.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Discounts
{
    public class DiscountCode : DiscountBase
    {
        public string Code { get; set; }
    }
}
