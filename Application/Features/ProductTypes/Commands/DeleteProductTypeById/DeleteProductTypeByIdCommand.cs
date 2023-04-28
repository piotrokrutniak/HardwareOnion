using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProductTypeById
{
    public class DeleteProductTypeByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteProductTypeByIdCommandHandler : IRequestHandler<DeleteProductTypeByIdCommand, Response<int>>
        {
            private readonly IProductTypeRepositoryAsync _productTypeRepository;
            public DeleteProductTypeByIdCommandHandler(IProductTypeRepositoryAsync productTypeRepository)
            {
                _productTypeRepository = productTypeRepository;
            }
            public async Task<Response<int>> Handle(DeleteProductTypeByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _productTypeRepository.GetByIdAsync(command.Id);
                if (product == null) throw new ApiException($"Product Type Not Found.");
                await _productTypeRepository.DeleteAsync(product);
                return new Response<int>(product.Id);
            }
        }
    }
}
