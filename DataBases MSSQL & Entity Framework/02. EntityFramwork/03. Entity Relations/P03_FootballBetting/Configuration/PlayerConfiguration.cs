using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.PlayerId);

            builder.Property(p => p.Name)
                .IsRequired();

            builder.HasOne(e => e.Team)
                .WithMany(e => e.Players)
                .HasForeignKey(e => e.TeamId);

            builder.HasOne(e => e.Position)
                .WithMany(e => e.Players)
                .HasForeignKey(e => e.PositionId);
        }
    }
}
