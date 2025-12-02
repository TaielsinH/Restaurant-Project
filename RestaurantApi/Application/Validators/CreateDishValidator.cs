using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{   //Se usará validator para validar el formato de entrada.
    //Las validaciones que requieran acceso a DB se harán en el servicio.
    public class CreateDishValidator : AbstractValidator<CreateDishRequest>
    {
        public CreateDishValidator()
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