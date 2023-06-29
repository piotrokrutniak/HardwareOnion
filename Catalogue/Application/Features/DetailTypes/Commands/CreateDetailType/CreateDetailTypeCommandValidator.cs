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

namespace Application.Features.DetailTypes.Commands.CreateDetailType
{
    public class CreateDetailTypeCommandValidator : AbstractValidator<CreateDetailTypeCommand>
    {
        private readonly IDetailTypeRepositoryAsync detailTypeRepository;

        public CreateDetailTypeCommandValidator(IDetailTypeRepositoryAsync detailTypeRepository)
        {
            this.detailTypeRepository = detailTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
                .MustAsync(IsUnique).WithMessage("{PropertyName} already exists.");
            RuleFor(p => p.DetailStyle)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 30 characters.");
        }

        private async Task<bool> IsUnique(string name, CancellationToken cancellationToken)
        {
            var types = await detailTypeRepository.GetAllAsync();

            bool typeUnique = false;

            if (types.Any())
            {
                typeUnique = types.SingleOrDefault().Name.Equals(name);
            }

            return await Task.FromResult(!typeUnique);
        }
    }
}
