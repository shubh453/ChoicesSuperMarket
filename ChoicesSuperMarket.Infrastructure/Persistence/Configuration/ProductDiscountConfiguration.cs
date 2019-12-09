using ChoicesSuperMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoicesSuperMarket.Infrastructure.Persistence.Configuration
{
    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
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

            builder.HasOne(d => d.Product)
                .WithOne(p => p.ProductDiscount)
                .HasForeignKey<ProductDiscount>(d => d.ProductId);
        }
    }
}