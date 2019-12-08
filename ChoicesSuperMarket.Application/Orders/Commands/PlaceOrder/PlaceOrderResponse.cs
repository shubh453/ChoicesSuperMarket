using ChoicesSuperMarket.Application.Common.Abstract;
using ChoicesSuperMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Application.Orders.Commands.PlaceOrder
{
    public class PlaceOrderResponse : BaseResponse
    {
        public ICollection<PlacedProductVM> PlacedProducts { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal SavedAmount { get; set; }
    }

    public class PlacedProductVM
    {
        public string ProductName { get; set; }
        public int Units { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal DiscountAmount { get; set; }

    }
}
