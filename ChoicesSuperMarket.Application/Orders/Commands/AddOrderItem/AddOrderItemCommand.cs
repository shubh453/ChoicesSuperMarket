using ChoicesSuperMarket.Application.Interfaces;
using ChoicesSuperMarket.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Orders.Commands.AddOrderItem
{
    public class AddOrderItemCommand : IRequest<AddOrderItemResponse>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, AddOrderItemResponse>
        {
            private readonly IAppDbContext _context;

            public AddOrderItemCommandHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<AddOrderItemResponse> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    Order order = null;
                    order = await _context.Orders.Where(o => o.BuyerId == request.CustomerId && o.IsActive).Include(o => o.OrderItems).FirstOrDefaultAsync();
                    if (order == null)
                    {
                        order = new Order(request.CustomerId, DateTimeOffset.Now);
                    }

                    var existingOrderItemInOrder = order.OrderItems.Where(oi => oi.ProductId == request.ProductId).FirstOrDefault();
                    if (existingOrderItemInOrder != null)
                    {
                        existingOrderItemInOrder.AddUnit();
                        _context.OrderItems.Update(existingOrderItemInOrder);
                    }
                    else
                    {
                        var product = await _context.Products.Where(p => p.Id == request.ProductId).FirstOrDefaultAsync();

                        var newOrderItem = new OrderItem(product, order, 1);

                        await _context.OrderItems.AddAsync(newOrderItem);
                    }

                    await _context.SaveChangesAsync(cancellationToken);
                    return new AddOrderItemResponse { Exception = null, IsAdded = true, Message = $"Product with productId : {request.ProductId} added successfully in the cart", Success = true };
                }
                catch (Exception ex)
                {
                    return new AddOrderItemResponse { Exception = ex, IsAdded = false, Message = "Error occurred while adding new product in the cart", Success = false };
                }
            }
        }
    }
}