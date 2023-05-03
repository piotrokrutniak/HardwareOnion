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

namespace Application.Features.ProductTypes.Queries.GetAllProductTypes
{
    public class GetAllProductTypesQuery : IRequest<PagedResponse<IEnumerable<GetAllProductTypesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GGetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, PagedResponse<IEnumerable<GetAllProductTypesViewModel>>>
    {
        private readonly IProductTypeRepositoryAsync _productTypeRepository;
        private readonly IMapper _mapper;
        public GGetAllProductTypesQueryHandler(IProductTypeRepositoryAsync productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductTypesViewModel>>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProductTypesParameter>(request);
            var product = await _productTypeRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<GetAllProductTypesViewModel>>(product);
            return new PagedResponse<IEnumerable<GetAllProductTypesViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
