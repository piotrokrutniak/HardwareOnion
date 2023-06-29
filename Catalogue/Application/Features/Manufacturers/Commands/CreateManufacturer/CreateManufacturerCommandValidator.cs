using Application.Features.DetailTypes.Commands.CreateDetailType;
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

namespace Application.Features.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandValidator : AbstractValidator<CreateManufacturerCommand>
    {
        private readonly IManufacturerRepositoryAsync manufacturerRepository;

        public CreateManufacturerCommandValidator(IManufacturerRepositoryAsync manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
                .MustAsync(IsUnique).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUnique(string name, CancellationToken cancellationToken)
        {
            var types = await manufacturerRepository.GetAllAsync();

            bool typeUnique = false;

            if (types.Any())
            {
                typeUnique = types.FirstOrDefault().Name.Equals(name);
            }

            return await Task.FromResult(!typeUnique);
        }
    }
}
