
using AutoMapper;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Images;
using Application.Features.Images.Commands;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateImageCommand, Image>();
        }
    }
}
