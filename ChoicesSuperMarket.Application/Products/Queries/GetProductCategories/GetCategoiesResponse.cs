using ChoicesSuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Products.Queries.GetProductCategories
{
    public class GetCategoiesResponse
    {
        public ICollection<CategoryVM> Categories { get; set; }
    }

    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public ICollection<SubCategoryVM> SubCategories { get; set; }
    }
    public class SubCategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
    }
}
