using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Application.Dtos.Requests;

namespace Application.Validators
{
    public class GetDishByIdValidator : AbstractValidator<GuidRequest>
    {
        public GetDishByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El ID es obligatorio")
                .Must(BeAValidGuid).WithMessage("Formato de ID inválido");
        }
        private bool BeAValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}