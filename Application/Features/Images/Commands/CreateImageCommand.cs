using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models.Images;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Images.Commands
{
        public partial class CreateImageCommand : IRequest<Response<int>>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public int ImageTypeId { get; set; }
            public int ManufacturerId { get; set; }
            
            public IFormFile ImageFile { get; set; }
        }
        public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Response<int>>
        {
            private readonly IImageRepositoryAsync _imageRepository;
            private readonly IMapper _mapper;
            public CreateImageCommandHandler(IImageRepositoryAsync imageRepository, IMapper mapper)
            {
                _imageRepository = imageRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
            {
                var image = _mapper.Map<Image>(request);
                await _imageRepository.AddAsync(image);

                return new Response<int>(image.Id);
            }
        }
}
