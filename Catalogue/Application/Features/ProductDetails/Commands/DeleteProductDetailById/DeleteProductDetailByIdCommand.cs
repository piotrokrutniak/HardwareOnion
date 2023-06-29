using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductDetails.Commands.DeleteProductDetailById
{
    public class DeleteProductDetailByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteDetailTypeByIdCommandHandler : IRequestHandler<DeleteProductDetailByIdCommand, Response<int>>
        {
            private readonly IProductDetailRepositoryAsync _productDetailRepository;
            public DeleteDetailTypeByIdCommandHandler(IProductDetailRepositoryAsync productDetailRepository)
            {
                _productDetailRepository = productDetailRepository;
            }
            public async Task<Response<int>> Handle(DeleteProductDetailByIdCommand command, CancellationToken cancellationToken)
            {
                var productDetail = await _productDetailRepository.GetByIdAsync(command.Id);
                if (productDetail == null) throw new ApiException($"Detail Type Not Found.");
                await _productDetailRepository.DeleteAsync(productDetail);
                return new Response<int>(productDetail.Id);
            }
        }
    }
}
