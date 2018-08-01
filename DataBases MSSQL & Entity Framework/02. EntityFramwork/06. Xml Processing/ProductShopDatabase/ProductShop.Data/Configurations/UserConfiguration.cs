using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models;

namespace ProductShop.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Age)
                .IsRequired(false);

            builder.HasMany(e => e.ProductsBought)
                .WithOne(e => e.Buyer)
                .HasForeignKey(e => e.BuyerId);

            builder.HasMany(e => e.ProductsSold)
                .WithOne(e => e.Seller)
                .HasForeignKey(e => e.SellerId);
        }
    }
}
