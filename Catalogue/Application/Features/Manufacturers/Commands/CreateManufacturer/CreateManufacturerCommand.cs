using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Manufacturers.Commands.CreateManufacturer
{
    public partial class CreateManufacturerCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, Response<int>>
    {
        private readonly IManufacturerRepositoryAsync _manufacturerRepository;
        private readonly IMapper _mapper;
        public CreateManufacturerCommandHandler(IManufacturerRepositoryAsync manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = _mapper.Map<Manufacturer>(request);
            await _manufacturerRepository.AddAsync(manufacturer);
            return new Response<int>(manufacturer.Id);
        }
    }
}
