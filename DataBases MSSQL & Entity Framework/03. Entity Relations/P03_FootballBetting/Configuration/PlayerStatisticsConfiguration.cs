using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class PlayerStatisticsConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(e => new
            {
                e.GameId,
                e.PlayerId
            });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerStatistics)
                .HasForeignKey(e => e.PlayerId);

            builder.HasOne(e => e.Game)
                .WithMany(e => e.PlayerStatistics)
                .HasForeignKey(e => e.GameId);
        }
    }
}
