using ChoicesSuperMarket.Application.Products.Queries.GetProductCategories;
using ChoicesSuperMarket.Application.Products.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Presentation.Models
{
    public class ProductPageViewModel
    {
        public GetCategoiesResponse Categories { get; set; }
        public GetProductResponse Products { get; set; }
    }
}
