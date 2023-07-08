using Application.Enums;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IOrderRepositoryAsync orderRepository;

        public CreateOrderCommandValidator(IOrderRepositoryAsync orderRepository)
        {
            this.orderRepository = orderRepository;

            RuleFor(p => p.OrderStatus)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.UserEmail)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress();

        }

        /*
        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await orderRepository.IsUniqueBarcodeAsync(barcode);
        }
        */

        private async Task<bool> IsUniqueBarcode(int id, CancellationToken cancellationToken)
        {
            return  await orderRepository.GetByIdAsync(id) == null;
        }

    }
}
