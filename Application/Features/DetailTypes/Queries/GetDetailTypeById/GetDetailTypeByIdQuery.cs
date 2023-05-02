using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DetailTypes.Queries.GetDetailTypeById
{
    public class GetDetailTypeByIdQuery : IRequest<Response<DetailType>>
    {
        public int Id { get; set; }
        public class GetDetailTypeByIdQueryHandler : IRequestHandler<GetDetailTypeByIdQuery, Response<DetailType>>
        {
            private readonly IDetailTypeRepositoryAsync _detailTypeRepository;
            public GetDetailTypeByIdQueryHandler(IDetailTypeRepositoryAsync detailTypeRepository)
            {
                _detailTypeRepository = detailTypeRepository;
            }
            public async Task<Response<DetailType>> Handle(GetDetailTypeByIdQuery query, CancellationToken cancellationToken)
            {
                var detailType = await _detailTypeRepository.GetByIdAsync(query.Id);
                if (detailType == null) throw new ApiException($"Detail Type Not Found.");
                return new Response<DetailType>(detailType);
            }
        }
    }
}
