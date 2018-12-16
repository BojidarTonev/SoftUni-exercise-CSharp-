using Microsoft.EntityFrameworkCore;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<TaskSector> TaskSectors { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Torshia;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskSector>()
                .HasKey(ts => new {ts.SectorId, ts.TaskId});

            modelBuilder.Entity<Report>()
                .HasOne(p => p.Task)
                .WithOne(i => i.Report)
                .HasForeignKey<Report>(b => b.TaskId);
        }
    }
}
