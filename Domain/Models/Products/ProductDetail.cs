﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Models.Products
{
    public class ProductDetail : AuditableBaseEntity
    {
        public int DetailTypeId { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public virtual DetailType DetailType { get; set; }
        public virtual Product Product { get; set; }
    }
}
