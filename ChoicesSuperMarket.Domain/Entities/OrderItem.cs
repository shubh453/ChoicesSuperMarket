using ChoicesSuperMarket.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public int Units { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int OrderId { get; private set; }
        public Order Order { get; private set; }
        private OrderItem()
        { }

        public OrderItem(Product product, Order order ,int units)
        {
            Product = product;
            Order = order;
            Units = units;
        }

        public void AddUnit()
        {
            Units++;
        }
        public void RemoveUnit()
        {
            if (Units == 0)
                throw new InvalidOperationException();
            Units--;
        }
    }
}
