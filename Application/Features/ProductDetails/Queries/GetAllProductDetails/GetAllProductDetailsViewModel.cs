using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ProductDetails.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsViewModel
    {
        public int Id { get; set; }
        public int DetailTypeId { get; set; }
        public string Description { get; set; }
        public DetailType DetailType { get; set; }
        public int ProductId { get; set; }

    }
}
