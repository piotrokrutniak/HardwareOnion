using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductDetails.Queries.GetProductDetailById
{
    public class GetProductDetailsByIdQuery : IRequest<Response<ProductDetail>>
    {
        public int Id { get; set; }
        public class GetProductDetailByIdQueryHandler : IRequestHandler<GetProductDetailsByIdQuery, Response<ProductDetail>>
        {
            private readonly IProductDetailRepositoryAsync _productDetailRepository;
            public GetProductDetailByIdQueryHandler(IProductDetailRepositoryAsync productDetailRepository)
            {
                _productDetailRepository = productDetailRepository;
            }
            public async Task<Response<ProductDetail>> Handle(GetProductDetailsByIdQuery query, CancellationToken cancellationToken)
            {
                var productDetail = await _productDetailRepository.GetByIdAsync(query.Id);
                if (productDetail == null) throw new ApiException($"Product Detail Not Found.");
                return new Response<ProductDetail>(productDetail);
            }
        }
    }
}
