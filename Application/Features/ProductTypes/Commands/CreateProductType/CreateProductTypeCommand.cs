using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductTypes.Commands.CreateProductType
{
    public partial class CreateProductTypeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Response<int>>
    {
        private readonly IProductTypeRepositoryAsync _productTypeRepository;
        private readonly IMapper _mapper;
        public CreateProductTypeCommandHandler(IProductTypeRepositoryAsync productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var productType = _mapper.Map<ProductType>(request);
            await _productTypeRepository.AddAsync(productType);
            return new Response<int>(productType.Id);
        }
    }
}
