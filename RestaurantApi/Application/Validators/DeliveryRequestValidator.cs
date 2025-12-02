using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class DeliveryRequestValidator : AbstractValidator<DeliveryRequest>
    {
        public DeliveryRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El campo Id de delivery es obligatorio");
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("Se debe especificar a donde se lleva el delivery");
            
        }
    }
}