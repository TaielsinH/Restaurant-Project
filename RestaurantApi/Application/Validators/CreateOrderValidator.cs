using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("Debe haber al menos un item en la orden");

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemValidator());

            RuleFor(x => x.Delivery)
                .NotNull().WithMessage("La informanción de Delivery es obligatoria")
                .SetValidator(new DeliveryRequestValidator());

            RuleFor(x => x.Notes)
                .NotNull().WithMessage("tiene que haber una nota");
        }
    }
}