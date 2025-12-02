using Application.Dtos.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class OrderSearchRequestValidator : AbstractValidator<OrderSearchRequest>
    {
        public OrderSearchRequestValidator()
        {
            RuleFor(x => x.To)
                .GreaterThanOrEqualTo(x => x.From)
                .When(x => x.From.HasValue && x.To.HasValue)
                .WithMessage("Rango de fechas inválido");
        }
    }
}