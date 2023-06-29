using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Manufacturers.Commands.DeleteManufacturerById
{
    public class DeleteManufacturerByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteManufacturerByIdCommandHandler : IRequestHandler<DeleteManufacturerByIdCommand, Response<int>>
        {
            private readonly IManufacturerRepositoryAsync _manufacturerRepository;
            public DeleteManufacturerByIdCommandHandler(IManufacturerRepositoryAsync manufacturerRepository)
            {
                _manufacturerRepository = manufacturerRepository;
            }
            public async Task<Response<int>> Handle(DeleteManufacturerByIdCommand command, CancellationToken cancellationToken)
            {
                var manufacturer = await _manufacturerRepository.GetByIdAsync(command.Id);
                if (manufacturer == null) throw new ApiException($"Manufacturer Not Found.");
                await _manufacturerRepository.DeleteAsync(manufacturer);
                return new Response<int>(manufacturer.Id);
            }
        }
    }
}
