﻿using ChoicesSuperMarket.Domain.Abstract;
using ChoicesSuperMarket.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; private set; }
        public short QuantityInPackage { get; private set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; private set; }
        public double Price { get; private set; }
        public string PictureUri { get; private set; }
        public int SubCategoryId { get; private set; }
        public SubCategory SubCategory { get; private set; }
        public ProductDiscount ProductDiscount { get; private set; }

        public Product(
            string name,
            short quantityInPackage,
            EUnitOfMeasurement unitOfMeasurement,
            double price,
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