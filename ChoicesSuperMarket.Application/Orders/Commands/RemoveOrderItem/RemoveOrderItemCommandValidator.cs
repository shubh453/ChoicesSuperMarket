using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Orders.Commands.RemoveOrderItem
{
    public class RemoveOrderItemCommandValidator : AbstractValidator<RemoveOrderItemCommand>
    {
        public RemoveOrderItemCommandValidator()
        {
            RuleFor(v => v.CustomerId)
                .NotEqual(0)
                .NotNull();
            RuleFor(v => v.ProductId)
                .NotEqual(0)
                .NotNull();
        }
    }
}
