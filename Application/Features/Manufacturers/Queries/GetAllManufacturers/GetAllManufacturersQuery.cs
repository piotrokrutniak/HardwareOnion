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

namespace Application.Features.Manufacturers.Queries.GetAllManufacturers
{
    public class GetAllManufacturersQuery : IRequest<PagedResponse<IEnumerable<GetAllManufacturersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GGetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, PagedResponse<IEnumerable<GetAllManufacturersViewModel>>>
    {
        private readonly IManufacturerRepositoryAsync _manufacturerRepository;
        private readonly IMapper _mapper;
        public GGetAllManufacturersQueryHandler(IManufacturerRepositoryAsync manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllManufacturersViewModel>>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllManufacturersParameter>(request);
            var manufacturer = await _manufacturerRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var manufacturerViewModel = _mapper.Map<IEnumerable<GetAllManufacturersViewModel>>(manufacturer);
            return new PagedResponse<IEnumerable<GetAllManufacturersViewModel>>(manufacturerViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}
