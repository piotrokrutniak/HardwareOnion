using Application.Features.Products.Queries.GetAllProducts;
using Application.Filters;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductDetails.Queries.GetAllProductDetails
{
    public class GetAllProductDetailsQuery : IRequest<PagedResponse<IEnumerable<GetAllProductDetailsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllProductDetailsQueryHandler : IRequestHandler<GetAllProductDetailsQuery, PagedResponse<IEnumerable<GetAllProductDetailsViewModel>>>
    {
        private readonly IProductDetailRepositoryAsync _productDetailRepository;
        private readonly IMapper _mapper;
        public GetAllProductDetailsQueryHandler(IProductDetailRepositoryAsync productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductDetailsViewModel>>> Handle(GetAllProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProductDetailsByProductIdParameter>(request);
            var productDetail = await _productDetailRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var productDetailViewModel = _mapper.Map<IEnumerable<GetAllProductDetailsViewModel>>(productDetail);
            return new PagedResponse<IEnumerable<GetAllProductDetailsViewModel>>(productDetailViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
