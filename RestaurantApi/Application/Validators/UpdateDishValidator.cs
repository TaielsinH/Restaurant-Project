using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateDishValidator : AbstractValidator<UpdateDishRequest>
    {
        public UpdateDishValidator()
        {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("El nombre es obligatorio")
                   .MaximumLength(255).WithMessage("Máximo de 255 caracteres");
            RuleFor(d => d.Description)
                   .NotEmpty().WithMessage("Descripción obligatoria");
            RuleFor(d => d.Image)
                   .NotEmpty().WithMessage("Imagen obligatoria");
            RuleFor(d => d.Price)
                   .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");
        }
    }
}