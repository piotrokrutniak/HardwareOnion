using Application.Features.Orders.Queries.GetAllOrders;
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

namespace Application.Features.DetailTypes.Queries.GetAllDetailTypes
{
    public class GetAllDetailTypesQuery : IRequest<PagedResponse<IEnumerable<GetAllDetailTypesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllDetailTypesQueryHandler : IRequestHandler<GetAllDetailTypesQuery, PagedResponse<IEnumerable<GetAllDetailTypesViewModel>>>
    {
        private readonly IDetailTypeRepositoryAsync _detailTypeRepository;
        private readonly IMapper _mapper;
        public GetAllDetailTypesQueryHandler(IDetailTypeRepositoryAsync detailTypeRepository, IMapper mapper)
        {
            _detailTypeRepository = detailTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllDetailTypesViewModel>>> Handle(GetAllDetailTypesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllDetailTypesParameter>(request);
            var detailType = await _detailTypeRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var detailTypeViewModel = _mapper.Map<IEnumerable<GetAllDetailTypesViewModel>>(detailType);
            return new PagedResponse<IEnumerable<GetAllDetailTypesViewModel>>(detailTypeViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
