using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Models;
using FluentValidation;

namespace Application.Validators
{
    public class DishQueryParametersValidator : AbstractValidator<DishQueryParameters>
    {
        public DishQueryParametersValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(255).WithMessage("El nombre no puede superar los 255 caracteres");

            RuleFor(p => p.Category)
                .GreaterThan(0).When(p => p.Category.HasValue).WithMessage("La categoria debe ser un número positivo");
            RuleFor(p => p.SortByPrice)
                .IsInEnum()
                .WithMessage("El parámetro de ordenamiento debe ser 'asc', 'desc', o vacío");
        }
    }
}