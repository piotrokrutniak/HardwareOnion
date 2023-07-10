using Domain.Models.Common;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Manufacturer : AuditableBaseEntity
    {
        public Manufacturer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
