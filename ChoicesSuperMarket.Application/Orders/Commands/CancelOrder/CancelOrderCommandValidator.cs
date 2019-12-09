using FluentValidation;

namespace ChoicesSuperMarket.Application.Orders.Commands.CancelOrder
{
    public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotNull()
                .NotEqual(0);
        }
    }
}