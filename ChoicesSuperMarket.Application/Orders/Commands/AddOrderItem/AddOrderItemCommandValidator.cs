using FluentValidation;

namespace ChoicesSuperMarket.Application.Orders.Commands.AddOrderItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
        {
            RuleFor(v => v.CustomerId)
                .NotNull()
                .NotEqual(0);
            RuleFor(v => v.ProductId)
                .NotNull()
                .NotEqual(0);
        }
    }
}