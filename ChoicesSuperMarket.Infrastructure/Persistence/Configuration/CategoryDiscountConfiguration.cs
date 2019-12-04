using ChoicesSuperMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChoicesSuperMarket.Infrastructure.Persistence.Configuration
{
    public class CategoryDiscountConfiguration : IEntityTypeConfiguration<CategoryDiscount>
    {
        public void Configure(EntityTypeBuilder<CategoryDiscount> builder)
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

            builder.HasOne(d => d.Category)
                .WithOne(c => c.CategoryDiscount)
                .HasForeignKey<CategoryDiscount>(d => d.CategoryId);
        }
    }
}
