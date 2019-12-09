using ChoicesSuperMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoicesSuperMarket.Infrastructure.Persistence.Configuration
{
    public class SubCategoryDiscountConfiguration : IEntityTypeConfiguration<SubCategoryDiscount>
    {
        public void Configure(EntityTypeBuilder<SubCategoryDiscount> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.DiscountType)
                .IsRequired();

            builder.Property(d => d.DiscountPercentage)
                .IsRequired()
                .HasColumnType("Decimal (4, 2)");

            builder.HasOne(d => d.SubCategory)
                .WithOne(sc => sc.SubCategoryDiscount)
                .HasForeignKey<SubCategoryDiscount>(d => d.SubCategoryId);
        }
    }
}