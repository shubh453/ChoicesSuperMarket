using ChoicesSuperMarket.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Products.Queries.GetProductCategories
{
    public class GetCategoriesQuery : IRequest<GetCategoiesResponse>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoiesResponse>
        {
            private readonly IAppDbContext context;

            public GetCategoriesQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }

            public async Task<GetCategoiesResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
            {
                try
                {

                    var categories = await context.Categories
                                                  .Include(c => c.CategoryDiscount)
                                                  .Include(c => c.SubCategories)
                                                  .ThenInclude(sc => sc.SubCategoryDiscount).ToListAsync();
                    var categoryVM = new List<CategoryVM>();
                    foreach (var category in categories)
                    {
                        var subcategoryVM = new List<SubCategoryVM>();

                        foreach (var subcategory in category.SubCategories)
                        {
                            subcategoryVM.Add(new SubCategoryVM { 
                                Id = subcategory.Id,
                                Name = subcategory.Name,
                                Discount = subcategory.SubCategoryDiscount.DiscountPercentage
                            });
                        }

                        categoryVM.Add(new CategoryVM
                        {
                            Id = category.Id,
                            Name = category.Name,
                            Discount = category.CategoryDiscount.DiscountPercentage,
                            SubCategories = subcategoryVM
                        });
                    }

                    return new GetCategoiesResponse { Categories = categoryVM };

                }
                catch (Exception)
                {
                    return new GetCategoiesResponse { Categories = null };
                }
            }
        }
    }
}
