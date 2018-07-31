using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealers.Data.Configuration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.Parts)
                .WithOne(e => e.Supplier)
                .HasForeignKey(e => e.SupplierId);
        }
    }
}
