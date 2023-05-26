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

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<IEnumerable<GetAllProductsViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductsViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            int productCount = await _productRepository.CountAsync();
            int lastPage = GetMaxPage(request.PageSize, productCount);
            request.PageNumber = ValidatePageNumber(request, lastPage);

            var validFilter = _mapper.Map<GetAllProductsParameter>(request);
            var product = await _productRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize, request.OrderBy);
            var productViewModel = _mapper.Map<IEnumerable<GetAllProductsViewModel>>(product);
            return new PagedResponse<IEnumerable<GetAllProductsViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize, lastPage);           
        }

        private int ValidatePageNumber(GetAllProductsQuery request, int lastPage)
        {
            if (request.PageNumber > lastPage)
            {
                request.PageNumber = lastPage;
            }

            return request.PageNumber;
        }

        private int GetMaxPage(int pageSize, int productCount)
        {
            return _productRepository.GetMaxPage(pageSize, productCount);
        }
    }
}
