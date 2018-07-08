using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.TeamId);

            builder.HasOne(e => e.Town)
                .WithMany(e => e.Teams)
                .HasForeignKey(e => e.TownId);

            builder.Property(t => t.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(t => t.LogoUrl)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
