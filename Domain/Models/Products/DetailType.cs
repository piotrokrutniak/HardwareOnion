using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Products
{
    public class DetailType : AuditableBaseEntity
    {
        public DetailType(string name, string detailStyle)
        {
            Name = name;
            DetailStyle = detailStyle;
        }
        public string Name { get; set; }
        public string DetailStyle { get; set; }
    }
}
