using ChoicesSuperMarket.Application.Products.Queries.GetProductCategories;
using ChoicesSuperMarket.Application.Products.Queries.GetProducts;

namespace ChoicesSuperMarket.Presentation.Models
{
    public class ProductPageViewModel
    {
        public GetCategoiesResponse Categories { get; set; }
        public GetProductResponse Products { get; set; }
    }
}