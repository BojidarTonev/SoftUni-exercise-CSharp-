using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(e => e.PositionId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(e => e.Players)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PlayerId);
        }
    }
}
