using ChoicesSuperMarket.Domain.Abstract;
using System;
using System.Collections.Generic;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class SubCategory : AuditableEntity
    {
        public string Name { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public SubCategoryDiscount SubCategoryDiscount { get; private set; }

        private readonly List<Product> products = new List<Product>();
        public IReadOnlyCollection<Product> Products => products.AsReadOnly();

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void AddProduct(IEnumerable<Product> products)
        {
            this.products.AddRange(products);
        }

        public void RemoveProduct(int productId)
        {
            products.Remove(products.Find(x => x.Id == productId));
        }

        public SubCategory(string name, Category category)
        {
            Name = name;
            Category = category;
        }

        protected SubCategory()
        {
        }
    }
}