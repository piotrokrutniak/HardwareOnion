using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Products;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DetailTypes.Commands.CreateDetailType
{
    public partial class CreateDetailTypeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string DetailStyle { get; set; }
    }
    public class CreateDetailtTypeCommandHandler : IRequestHandler<CreateDetailTypeCommand, Response<int>>
    {
        private readonly IDetailTypeRepositoryAsync _detailTypeRepository;
        private readonly IMapper _mapper;
        public CreateDetailtTypeCommandHandler(IDetailTypeRepositoryAsync detailTypeRepository, IMapper mapper)
        {
            _detailTypeRepository = detailTypeRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDetailTypeCommand request, CancellationToken cancellationToken)
        {
            var detailType = _mapper.Map<DetailType>(request);
            await _detailTypeRepository.AddAsync(detailType);
            return new Response<int>(detailType.Id);
        }
    }
}
