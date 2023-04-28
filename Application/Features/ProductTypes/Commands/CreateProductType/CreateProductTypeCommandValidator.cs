using Application.Features.ProductTypes.Commands.CreateProductType;
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

namespace Application.Features.Products.Commands.CreateProductType
{
    public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
    {
        private readonly IProductTypeRepositoryAsync productRepository;

        public CreateProductTypeCommandValidator(IProductTypeRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUnique).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUnique(string name, CancellationToken cancellationToken)
        {
            var types = await productRepository.GetAllAsync();

            bool typeUnique = false;

            if (types.Any())
            {
                typeUnique = types.SingleOrDefault().Name.Equals(name);
            }

            return await Task.FromResult(!typeUnique);
        }
    }
}
