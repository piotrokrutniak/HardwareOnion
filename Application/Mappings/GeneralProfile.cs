using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.ProductTypes.Queries.GetAllProductTypes;
using Application.Features.ProductTypes.Commands.CreateProductType;
using AutoMapper;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Features.DetailTypes.Commands.CreateDetailType;
using Application.Features.DetailTypes.Queries.GetAllDetailTypes;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            
            CreateMap<ProductType, GetAllProductTypesViewModel>().ReverseMap();
            CreateMap<CreateProductTypeCommand, ProductType>();
            CreateMap<GetAllProductTypesQuery, GetAllProductTypesParameter>();

            CreateMap<DetailType, GetAllDetailTypesViewModel>().ReverseMap();
            CreateMap<CreateDetailTypeCommand, DetailType>();
            CreateMap<GetAllDetailTypesQuery, GetAllProductTypesParameter>();

        }
    }
}
