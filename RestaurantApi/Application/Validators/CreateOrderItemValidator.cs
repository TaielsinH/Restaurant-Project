using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemDto>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(oi => oi.Id)
                .NotEmpty().WithMessage("El producto es obligatorio");
            RuleFor(oi => oi.Quantity)
                .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0");
            RuleFor(oi => oi.Notes)
                .NotNull().WithMessage("Notes no puede ser null");
        }
    }
}