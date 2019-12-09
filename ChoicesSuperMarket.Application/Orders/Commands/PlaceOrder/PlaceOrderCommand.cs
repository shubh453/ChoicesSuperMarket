using ChoicesSuperMarket.Application.Common.Behaviour;
using ChoicesSuperMarket.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Orders.Commands.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<PlaceOrderResponse>
    {
        public int UserId { get; set; }

        public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResponse>
        {
            private readonly IAppDbContext context;

            public PlaceOrderCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    List<PlacedProductVM> placedProductVMs = new List<PlacedProductVM>();
                    decimal totalDiscount = 0m;
                    decimal totalAfterDiscount = 0m;
                    decimal total = 0m;

                    var ongoingOrder = await context.Orders.Where(o => o.IsActive && o.BuyerId == request.UserId).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync();
                    var customer = await context.Customers.Where(c => c.Id == request.UserId).FirstOrDefaultAsync();

                    if(ongoingOrder != null)
                    {
                        foreach (var item in ongoingOrder.OrderItems)
                        {
                            var product = await context.Products.Where(p => p.Id == item.Product.Id)
                                        .Include(p => p.ProductDiscount)
                                        .Include(p => p.SubCategory)
                                        .ThenInclude(sc => sc.SubCategoryDiscount)
                                        .Include(sc => sc.SubCategory)
                                        .ThenInclude(sc => sc.Category)
                                        .ThenInclude(c => c.CategoryDiscount)
                                        .FirstOrDefaultAsync();
                            var discount = 0m;
                            var discountedPrice = 0m;
                            var price = item.Product.Price * item.Units;

                            if (product.ProductDiscount.DiscountType == Domain.Enums.EDiscountType.PercentDiscount)
                            {

                                var percentageDiscount = Math.Max(Math.Max(product.ProductDiscount.DiscountPercentage,
                                                                  product.SubCategory.SubCategoryDiscount.DiscountPercentage),
                                                                  product.SubCategory.Category.CategoryDiscount.DiscountPercentage);

                                discount = (price * percentageDiscount) / 100;
                                discountedPrice = price - discount;
                            } 
                            else
                            {
                                var units = item.Units;
                                var disUnit = product.ProductDiscount.DiscountOnUnit;
                                var freeUnit = product.ProductDiscount.FreeUnit;
                                
                                while(units > 0)
                                {
                                    if(units > disUnit)
                                        discount += freeUnit * item.Product.Price;
                                    discountedPrice += Math.Min(units, disUnit) * item.Product.Price;
                                    units -= freeUnit + disUnit;
                                }
                            }

                            total += price;
                            totalDiscount += discount;
                            totalAfterDiscount += discountedPrice;

                            placedProductVMs.Add(new PlacedProductVM 
                            { 
                                Quantity = item.Units,
                                DiscountAmount = discount,
                                DiscountedPrice = discountedPrice,
                                Price = price,
                                ProductName = product.Name,
                                UnitOfMeasurement = product.UnitOfMeasurement.GetDescription()
                            });
                        }
                    }

                    return new PlaceOrderResponse
                    {
                        Exception = null,
                        Message = "Order invoice has been created",
                        SavedAmount = totalDiscount,
                        TotalAmount = totalAfterDiscount,
                        Success = true,
                        PlacedProducts = placedProductVMs,
                        CurrentCustomer = customer
                    };

                }
                catch (Exception ex)
                {
                    return new PlaceOrderResponse
                    {
                        Exception = ex,
                        Message = "Error occurred while calculating invoice amount",
                        SavedAmount = 0,
                        TotalAmount = 0,
                        Success = false,
                        PlacedProducts = null,
                        CurrentCustomer = null
                    };
                }
            }
        }
    }
}
