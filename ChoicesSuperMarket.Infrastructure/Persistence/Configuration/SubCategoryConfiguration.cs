using ChoicesSuperMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoicesSuperMarket.Infrastructure.Persistence.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(SubCategory.Products));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(c => c.Category)
               .WithMany(d => d.SubCategories)
               .HasForeignKey(c => c.CategoryId);
        }
    }
}