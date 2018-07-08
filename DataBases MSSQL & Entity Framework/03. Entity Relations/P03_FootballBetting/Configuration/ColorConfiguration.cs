using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(e => e.ColorId);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(e => e.PrimaryKitTeams)
                .WithOne(e => e.PrimaryKitColor)
                .HasForeignKey(e => e.PrimaryKitColorId);

            builder.HasMany(e => e.SecondaryKitTeams)
                .WithOne(e => e.SecondaryKitColor)
                .HasForeignKey(e => e.SecondaryKitColorId);
        }
    }
}
