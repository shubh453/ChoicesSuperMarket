using ChoicesSuperMarket.Domain.Abstract;
using ChoicesSuperMarket.Domain.Enums;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class CategoryDiscount : AuditableEntity
    {
        public string Name { get; set; }
        public EDiscountType DiscountType { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public int DiscountOnUnit { get; private set; }
        public int FreeUnit { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public CategoryDiscount(
           string name,
           decimal discountPercentage,
           Category category)
        {
            Name = name;
            DiscountType = EDiscountType.PercentDiscount;
            DiscountPercentage = discountPercentage;
            Category = category;
        }

        public CategoryDiscount(
            string name,
            int discountOnUnit,
            int freeUnit,
            Category category)
        {
            Name = name;
            DiscountType = EDiscountType.UnitDiscount;
            DiscountOnUnit = discountOnUnit;
            FreeUnit = freeUnit;
            Category = category;
        }

        protected CategoryDiscount()
        {
        }
    }
}