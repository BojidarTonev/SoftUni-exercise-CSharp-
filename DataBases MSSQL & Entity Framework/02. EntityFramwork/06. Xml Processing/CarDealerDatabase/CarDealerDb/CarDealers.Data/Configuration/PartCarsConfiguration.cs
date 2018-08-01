namespace CarDealers.Data.Configuration
{
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartCarsConfiguration : IEntityTypeConfiguration<PartCars>
    {
        public void Configure(EntityTypeBuilder<PartCars> builder)
        {
            builder.HasKey(e => new {e.CarId, e.PartId});

            builder.HasOne(e => e.Part)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.PartId);

            builder.HasOne(e => e.Car)
                .WithMany(e => e.Parts)
                .HasForeignKey(e => e.CarId);
        }
    }
}
