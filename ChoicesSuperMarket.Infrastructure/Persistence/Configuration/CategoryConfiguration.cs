using ChoicesSuperMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoicesSuperMarket.Infrastructure.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Category.SubCategories));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}