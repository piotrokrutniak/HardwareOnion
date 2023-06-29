using Application.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ProductDetails.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsByProductIdParameter : RequestParameter
    {
        public int ProductId { get; set; }
    }
}
