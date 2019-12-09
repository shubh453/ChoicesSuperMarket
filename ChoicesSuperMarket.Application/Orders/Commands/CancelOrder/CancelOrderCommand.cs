using ChoicesSuperMarket.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest<CancelOrderResponse>
    {
        public int UserId { get; set; }

        public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CancelOrderResponse>
        {
            private readonly IAppDbContext context;

            public CancelOrderCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<CancelOrderResponse> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var ongoingOrder = await context.Orders.Where(o => o.IsActive && o.BuyerId == request.UserId).FirstOrDefaultAsync();

                    if (ongoingOrder != null)
                    {
                        ongoingOrder.MarkInactive();
                        await context.SaveChangesAsync(cancellationToken);
                    }
                    else
                    {
                        return new CancelOrderResponse { Exception = null, IsCanceled = false, Message = $"There is no ongoing order for the current customer.", Success = true };
                    }

                    return new CancelOrderResponse { Exception = null, IsCanceled = true, Message = $"Order with orderid: {ongoingOrder.Id} is canceled.", Success = true };
                }
                catch (Exception ex)
                {
                    return new CancelOrderResponse { Exception = ex, IsCanceled = false, Message = $"Error occured while cancelling the order. See Exception details.", Success = false };
                }
            }
        }
    }
}