using ChoicesSuperMarket.Application.Interfaces;
using ChoicesSuperMarket.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Orders.Commands.RemoveOrderItem
{
    public class RemoveOrderItemCommand : IRequest<RemoveOrderItemResponse>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderItemCommand, RemoveOrderItemResponse>
        {
            private readonly IAppDbContext _context;

            public RemoveOrderCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<RemoveOrderItemResponse> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    Order order = null;
                    order = await _context.Orders.Where(o => o.BuyerId == request.CustomerId && o.IsActive).Include(o => o.OrderItems).FirstOrDefaultAsync();
                    if (order == null)
                    {
                        return new RemoveOrderItemResponse { IsRemoved = false, Exception = new InvalidOperationException("Can not remove order which has not been placed"), Message = "Invalid Operation", Success = false };
                    }

                    var existingOrderItemInOrder = order.OrderItems.Where(oi => oi.ProductId == request.ProductId).FirstOrDefault();

                    if (existingOrderItemInOrder != null)
                    {
                        existingOrderItemInOrder.RemoveUnit();
                        _context.OrderItems.Update(existingOrderItemInOrder);
                    }
                    else
                    {
                        return new RemoveOrderItemResponse { IsRemoved = false, Exception = new InvalidOperationException("Can not remove order item which has not been placed yet"), Message = "Invalid Operation", Success = false };
                    }
                    await _context.SaveChangesAsync(cancellationToken);

                    return new RemoveOrderItemResponse { Exception = null, IsRemoved = true, Message = $"Product with productId : {request.ProductId} removed successfully from the cart", Success = true };
                }
                catch (Exception ex)
                {
                    return new RemoveOrderItemResponse { Exception = ex, IsRemoved = false, Message = "Error occurred while removing product from the cart", Success = false };
                }
            }
        }
    }
}
