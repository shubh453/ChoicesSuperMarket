using ChoicesSuperMarket.Domain.Abstract;
using System.Collections.Generic;

namespace ChoicesSuperMarket.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; private set; }
        public CategoryDiscount CategoryDiscount { get; private set; }

        private readonly List<SubCategory> subCategories = new List<SubCategory>();
        public IReadOnlyCollection<SubCategory> SubCategories => subCategories.AsReadOnly();

        public Category(string name)
        {
            Name = name;
        }

        protected Category()
        {
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void AddSubCategory(SubCategory subCategory)
        {
            subCategories.Add(subCategory);
        }

        public void AddSubCategory(IEnumerable<SubCategory> subCategories)
        {
            this.subCategories.AddRange(subCategories);
        }

        public void RemoveSubCategory(int subCategoryId)
        {
            this.subCategories.Remove(this.subCategories.Find(x => x.Id == subCategoryId));
        }
    }
}