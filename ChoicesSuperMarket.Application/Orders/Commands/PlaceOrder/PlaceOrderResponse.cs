using ChoicesSuperMarket.Application.Common.Abstract;
using ChoicesSuperMarket.Domain.Entities;
using System.Collections.Generic;

namespace ChoicesSuperMarket.Application.Orders.Commands.PlaceOrder
{
    public class PlaceOrderResponse : BaseResponse
    {
        public ICollection<PlacedProductVM> PlacedProducts { get; set; }
        public Customer CurrentCustomer { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal SavedAmount { get; set; }
    }

    public class PlacedProductVM
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}