using ChoicesSuperMarket.Domain.Abstract;
using ChoicesSuperMarket.Domain.Enums;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; private set; }
        public short QuantityInPackage { get; private set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int SubCategoryId { get; private set; }
        public SubCategory SubCategory { get; private set; }
        public ProductDiscount ProductDiscount { get; private set; }

        public Product(
            string name,
            short quantityInPackage,
            EUnitOfMeasurement unitOfMeasurement,
            decimal price,
            string pictureUri,
            SubCategory subCategory)
        {
            Name = name;
            QuantityInPackage = quantityInPackage;
            UnitOfMeasurement = unitOfMeasurement;
            Price = price;
            PictureUri = pictureUri;
            SubCategory = subCategory;
        }

        protected Product()
        {
        }
    }
}