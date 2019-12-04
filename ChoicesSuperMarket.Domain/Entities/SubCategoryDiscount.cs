using ChoicesSuperMarket.Domain.Abstract;
using ChoicesSuperMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class SubCategoryDiscount : AuditableEntity
    {
        public string Name { get; set; }
        public EDiscountType DiscountType { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public int DiscountOnUnit { get; private set; }
        public int FreeUnit { get; private set; }

        public int SubCategoryId { get; private set; }
        public SubCategory SubCategory { get; private set; }


        public SubCategoryDiscount(
            string name,
            decimal discountPercentage,
            SubCategory subCategory)
        {
            Name = name;
            DiscountType = EDiscountType.PercentDiscount;
            DiscountPercentage = discountPercentage;
            SubCategory = subCategory;
        }

        public SubCategoryDiscount(
            string name,
            int discountOnUnit,
            int freeUnit,
            SubCategory subCategory)
        {
            Name = name;
            DiscountType = EDiscountType.UnitDiscount;
            DiscountOnUnit = discountOnUnit;
            FreeUnit = freeUnit;
            SubCategory = subCategory;
        }

        protected SubCategoryDiscount()
        {
        }
    }
}
