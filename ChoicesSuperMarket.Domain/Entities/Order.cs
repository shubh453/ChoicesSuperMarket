using ChoicesSuperMarket.Domain.Abstract;
using System;
using System.Collections.Generic;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int BuyerId { get; private set; }
        public bool IsActive { get; private set; }
        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.Product.Price * item.Units;
            }
            return total;
        }

        public Order(int buyerId, DateTimeOffset orderDate)
        {
            BuyerId = buyerId;
            OrderDate = orderDate;
            IsActive = true;
        }

        protected Order()
        {
        }

        public void MarkInactive()
        {
            IsActive = false;
        }
    }
}