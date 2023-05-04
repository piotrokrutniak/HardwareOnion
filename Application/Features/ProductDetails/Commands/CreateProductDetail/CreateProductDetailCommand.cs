using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductDetails.Commands.CreateProductDetail
{
    public partial class CreateProductDetailCommand : IRequest<Response<int>>
    {
        public int DetailTypeId { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public class CreateProductDetailCommandHandler : IRequestHandler<CreateProductDetailCommand, Response<int>>
        {
            private readonly IProductDetailRepositoryAsync _productDetailRepository;
            private readonly IMapper _mapper;
            public CreateProductDetailCommandHandler(IProductDetailRepositoryAsync productDetailRepository, IMapper mapper)
            {
                _productDetailRepository = productDetailRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateProductDetailCommand request, CancellationToken cancellationToken)
            {
                var productDetail = _mapper.Map<ProductDetail>(request);
                await _productDetailRepository.AddAsync(productDetail);
                return new Response<int>(productDetail.Id);
            }
        }
    }
}
