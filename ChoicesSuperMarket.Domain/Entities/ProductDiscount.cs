using ChoicesSuperMarket.Domain.Abstract;
using ChoicesSuperMarket.Domain.Enums;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class ProductDiscount : AuditableEntity
    {
        public string Name { get; set; }
        public EDiscountType DiscountType { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public int DiscountOnUnit { get; private set; }
        public int FreeUnit { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public ProductDiscount(
            string name,
            decimal discountPercentage,
            Product product)
        {
            Name = name;
            DiscountType = EDiscountType.PercentDiscount;
            DiscountPercentage = discountPercentage;
            Product = product;
        }

        public ProductDiscount(
            string name,
            int discountOnUnit,
            int freeUnit,
            Product product)
        {
            Name = name;
            DiscountType = EDiscountType.UnitDiscount;
            DiscountOnUnit = discountOnUnit;
            FreeUnit = freeUnit;
            Product = product;
        }

        protected ProductDiscount()
        {
        }
    }
}