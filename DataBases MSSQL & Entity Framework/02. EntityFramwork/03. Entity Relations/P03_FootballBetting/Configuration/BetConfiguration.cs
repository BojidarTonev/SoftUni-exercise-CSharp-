using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(e => e.BetId);

            builder.HasOne(e => e.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(e => e.GameId);
        }
    }
}
