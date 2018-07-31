namespace CarDealers.Data.Configuration
{
    using System;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
