using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderItems.Commands.CreateOrderItem
{
    public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
    {
        private readonly IOrderItemRepositoryAsync orderItemRepository;

        public CreateOrderItemCommandValidator(IOrderItemRepositoryAsync orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.OrderId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(1)
                .NotNull();

            RuleFor(p => p.OrderName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 30 characters.");
        }
    }
}
