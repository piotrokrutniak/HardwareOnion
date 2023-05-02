using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DetailTypes.Commands.DeleteDetailTypeById
{
    public class DeleteDetailTypeByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteDetailTypeByIdCommandHandler : IRequestHandler<DeleteDetailTypeByIdCommand, Response<int>>
        {
            private readonly IDetailTypeRepositoryAsync _detailTypeRepository;
            public DeleteDetailTypeByIdCommandHandler(IDetailTypeRepositoryAsync detailTypeRepository)
            {
                _detailTypeRepository = detailTypeRepository;
            }
            public async Task<Response<int>> Handle(DeleteDetailTypeByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _detailTypeRepository.GetByIdAsync(command.Id);
                if (product == null) throw new ApiException($"Detail Type Not Found.");
                await _detailTypeRepository.DeleteAsync(product);
                return new Response<int>(product.Id);
            }
        }
    }
}
