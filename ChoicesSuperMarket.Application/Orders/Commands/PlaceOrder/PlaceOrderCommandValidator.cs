using FluentValidation;

namespace ChoicesSuperMarket.Application.Orders.Commands.PlaceOrder
{
    public class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
    {
        public PlaceOrderCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotNull()
                .NotEqual(0);
        }
    }
}