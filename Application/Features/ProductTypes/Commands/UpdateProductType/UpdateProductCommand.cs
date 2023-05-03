using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductTypes.Commands.UpdateProductType

{
    public class UpdateProductTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, Response<int>>
        {
            private readonly IProductTypeRepositoryAsync _productTypeRepository;
            public UpdateProductTypeCommandHandler(IProductTypeRepositoryAsync productTypeRepository)
            {
                _productTypeRepository = productTypeRepository;
            }
            public async Task<Response<int>> Handle(UpdateProductTypeCommand command, CancellationToken cancellationToken)
            {
                var productType = await _productTypeRepository.GetByIdAsync(command.Id);

                if (productType == null)
                {
                    throw new ApiException($"Product Type Not Found.");
                }
                else
                {
                    productType.Name = command.Name;
                    await _productTypeRepository.UpdateAsync(productType);
                    return new Response<int>(productType.Id);
                }
            }
        }
    }
}
