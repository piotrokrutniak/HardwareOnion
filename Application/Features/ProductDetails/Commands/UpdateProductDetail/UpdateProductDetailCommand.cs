using MediatR;

using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductDetails.Commands.UpdateProductDetail

{
    public class UpdateProductDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int DetailTypeId { get; set; }
        public string Description { get; set; }
        public class UpdateProductDetailCommandHandler : IRequestHandler<UpdateProductDetailCommand, Response<int>>
        {
            private readonly IProductDetailRepositoryAsync _productDetailRepository;
            public UpdateProductDetailCommandHandler(IProductDetailRepositoryAsync productDetailRepository)
            {
                _productDetailRepository = productDetailRepository;
            }
            public async Task<Response<int>> Handle(UpdateProductDetailCommand command, CancellationToken cancellationToken)
            {
                var productDetail = await _productDetailRepository.GetByIdAsync(command.Id);

                if (productDetail == null)
                {
                    throw new ApiException($"Product Detail Not Found.");
                }
                else
                {
                    productDetail.DetailTypeId = command.DetailTypeId;
                    productDetail.Description = command.Description;
                    await _productDetailRepository.UpdateAsync(productDetail);
                    return new Response<int>(productDetail.Id);
                }
            }
        }
    }
}
