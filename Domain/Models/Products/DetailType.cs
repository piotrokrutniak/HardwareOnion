using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Products
{
    public class DetailType : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string DetailStyle { get; set; }
    }
}
