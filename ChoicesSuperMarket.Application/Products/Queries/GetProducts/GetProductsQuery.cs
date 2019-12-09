using ChoicesSuperMarket.Application.Common.Behaviour;
using ChoicesSuperMarket.Application.Interfaces;
using ChoicesSuperMarket.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductResponse>
    {
        public int SubCategoryId { get; set; }

        public GetProductsQuery(int subCategoryId)
        {
            SubCategoryId = subCategoryId;
        }

        public class GetProductsQueryHanlder : IRequestHandler<GetProductsQuery, GetProductResponse>
        {
            private readonly IAppDbContext _context;

            public GetProductsQueryHanlder(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<GetProductResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    ICollection<Product> products;

                    var user = await _context.Customers.Where(c => c.Name == "Anish Kumar").FirstOrDefaultAsync();

                    var ongoingOrder = await _context.Orders.Where(o => o.BuyerId == user.Id && o.IsActive).Include(o => o.OrderItems).FirstOrDefaultAsync();

                    if (request.SubCategoryId == 0)
                    {
                        products = await _context.Products.Include(p => p.ProductDiscount).ToListAsync();
                    }
                    else
                    {
                        products = await _context.Products
                                    .Where(p => p.SubCategory.Id == request.SubCategoryId)
                                    .Include(p => p.ProductDiscount)
                                    .ToListAsync();
                    }

                    if (products == null)
                    {
                        return new GetProductResponse { Message = $"Product not found. Total Count: 0", ProductList = null, Success = true, CurrentCustomer = user };
                    }

                    var productVM = new List<ProductVM>();

                    foreach (var product in products)
                    {
                        var units = 0;
                        if (ongoingOrder != null)
                        {
                            units = ongoingOrder.OrderItems.Where(oi => oi.ProductId == product.Id).Select(oi => oi.Units).FirstOrDefault();
                        }

                        productVM.Add(new ProductVM
                        {
                            Id = product.Id,
                            DiscountTitle = product.ProductDiscount.Name,
                            Name = product.Name,
                            PictureUri = product.PictureUri,
                            Price = product.Price,
                            Units = units,
                            UnitOfMeasurement = product.UnitOfMeasurement.GetDescription()
                        });
                    }
                    if (ongoingOrder != null)
                        return new GetProductResponse { Message = $"There is already an order in progress. Please Continue.", ProductList = productVM, Success = true, CurrentCustomer = user };

                    return new GetProductResponse { Message = $"Products found. Total Count: {products.Count}", ProductList = productVM, Success = true, CurrentCustomer = user };
                }
                catch (Exception ex)
                {
                    return new GetProductResponse { Message = $"Error Occurred while retriving products.", Exception = ex, Success = false, CurrentCustomer = null };
                }
            }
        }
    }
}