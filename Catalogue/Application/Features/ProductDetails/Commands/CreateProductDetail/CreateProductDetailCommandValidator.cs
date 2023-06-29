using Application.Features.DetailTypes.Commands.CreateDetailType;
using Application.Features.Manufacturers.Commands.CreateManufacturer;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models;
using Domain.Models.Products;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductDetails.Commands.CreateProductDetail
{
    public class CreateProductDetailCommandValidator : AbstractValidator<CreateProductDetailCommand>
    {
        private readonly IProductDetailRepositoryAsync productDetailRepository;

        public CreateProductDetailCommandValidator(IProductDetailRepositoryAsync productDetailRepository)
        {
            this.productDetailRepository = productDetailRepository;

            RuleFor(p => p.DetailTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(p => p.ProductId)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
