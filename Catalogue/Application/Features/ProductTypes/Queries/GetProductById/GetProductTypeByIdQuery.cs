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

namespace Application.Features.ProductTypes.Queries.GetProductTypeById
{
    public class GetProductTypeByIdQuery : IRequest<Response<ProductType>>
    {
        public int Id { get; set; }
        public class GetProductTypeByIdQueryHandler : IRequestHandler<GetProductTypeByIdQuery, Response<ProductType>>
        {
            private readonly IProductTypeRepositoryAsync _productRepository;
            public GetProductTypeByIdQueryHandler(IProductTypeRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<ProductType>> Handle(GetProductTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Product Type Not Found.");
                return new Response<ProductType>(product);
            }
        }
    }
}
