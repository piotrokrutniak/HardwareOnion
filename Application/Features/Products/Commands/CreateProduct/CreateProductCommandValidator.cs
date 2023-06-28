using Application.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Products;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepositoryAsync productRepository;

        public CreateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;

            RuleFor(p => p.ProductTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(9999);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(9999);

            RuleFor(p => p.ManufacturerId)
                .GreaterThanOrEqualTo(1);
        }

        /*
        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await productRepository.IsUniqueBarcodeAsync(barcode);
        }
        */

        private async Task<bool> IsUniqueBarcode(int id, CancellationToken cancellationToken)
        {
            return  await productRepository.GetByIdAsync(id) == null;
        }

    }
}
