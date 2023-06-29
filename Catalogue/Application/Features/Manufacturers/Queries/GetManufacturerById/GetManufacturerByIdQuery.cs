using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Models.Entities;
using Domain.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Manufacturers.Queries.GetManufacturerById
{
    public class GetManufacturerByIdQuery : IRequest<Response<Manufacturer>>
    {
        public int Id { get; set; }
        public class GetManufacturerByIdQueryHandler : IRequestHandler<GetManufacturerByIdQuery, Response<Manufacturer>>
        {
            private readonly IManufacturerRepositoryAsync _manufacturerRepository;
            public GetManufacturerByIdQueryHandler(IManufacturerRepositoryAsync manufacturerRepository)
            {
                _manufacturerRepository = manufacturerRepository;
            }
            public async Task<Response<Manufacturer>> Handle(GetManufacturerByIdQuery query, CancellationToken cancellationToken)
            {
                var manufacturer = await _manufacturerRepository.GetByIdAsync(query.Id);
                if (manufacturer == null) throw new ApiException($"Detail Type Not Found.");
                return new Response<Manufacturer>(manufacturer);
            }
        }
    }
}
