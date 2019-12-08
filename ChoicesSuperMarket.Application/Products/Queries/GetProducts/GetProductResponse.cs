﻿using ChoicesSuperMarket.Application.Common.Abstract;
using ChoicesSuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Products.Queries.GetProducts
{
    public class GetProductResponse: BaseResponse
    {
        public ICollection<ProductVM> Products { get; set; }
        public Customer CurrentCustomer { get; set; }
    }

    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public string PictureUri { get; set; }
        public string DiscountTitle { get; set; }
    }
}