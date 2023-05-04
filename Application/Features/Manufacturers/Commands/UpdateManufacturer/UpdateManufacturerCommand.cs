using MediatR;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Manufacturers.Commands.UpdateManufacturer

{
    public class UpdateManufacturerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, Response<int>>
        {
            private readonly IManufacturerRepositoryAsync _manufacturerRepository;
            public UpdateManufacturerCommandHandler(IManufacturerRepositoryAsync manufacturerRepository)
            {
                _manufacturerRepository = manufacturerRepository;
            }
            public async Task<Response<int>> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
            {
                var manufacturer = await _manufacturerRepository.GetByIdAsync(command.Id);

                if (manufacturer == null)
                {
                    throw new ApiException($"Manufacturer Not Found.");
                }
                else
                {
                    manufacturer.Name = command.Name;
                    await _manufacturerRepository.UpdateAsync(manufacturer);
                    return new Response<int>(manufacturer.Id);
                }
            }
        }
    }
}
