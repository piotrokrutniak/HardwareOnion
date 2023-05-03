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

namespace Application.Features.DetailTypes.Commands.UpdateDetailType

{
    public class UpdateDetailTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DetailStyle { get; set; }
        public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateDetailTypeCommand, Response<int>>
        {
            private readonly IDetailTypeRepositoryAsync _detailTypeRepository;
            public UpdateProductTypeCommandHandler(IDetailTypeRepositoryAsync detailTypeRepository)
            {
                _detailTypeRepository = detailTypeRepository;
            }
            public async Task<Response<int>> Handle(UpdateDetailTypeCommand command, CancellationToken cancellationToken)
            {
                var detailType = await _detailTypeRepository.GetByIdAsync(command.Id);

                if (detailType == null)
                {
                    throw new ApiException($"Detail Type Not Found.");
                }
                else
                {
                    detailType.Name = command.Name;
                    detailType.DetailStyle = command.DetailStyle;
                    await _detailTypeRepository.UpdateAsync(detailType);
                    return new Response<int>(detailType.Id);
                }
            }
        }
    }
}
