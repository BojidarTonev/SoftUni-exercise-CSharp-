using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.GameId);

            builder.Property(g => g.DateTime)
                .IsRequired();

            builder.Property(g => g.Result)
                .IsRequired();

            builder.HasOne(e => e.HomeTeam)
                .WithMany(e => e.HomeGames)
                .HasForeignKey(e => e.HomeTeamId);

            builder.HasOne(e => e.AwayTeam)
                .WithMany(e => e.AwayGames)
                .HasForeignKey(e => e.AwayTeamId);
        }
    }
}
