using PetClinic.Models;

namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext() { }

        public PetClinicContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalAid> AnimalAids { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }
        public DbSet<Vet> Vets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>()
                .HasMany(a => a.Procedures)
                .WithOne(a => a.Animal)
                .HasForeignKey(a => a.AnimalId);

            builder.Entity<ProcedureAnimalAid>()
                .HasKey(paa => new {paa.AnimalAidId, paa.ProcedureId});

            builder.Entity<ProcedureAnimalAid>()
                .HasOne(paa => paa.Procedure)
                .WithMany(paa => paa.ProcedureAnimalAids)
                .HasForeignKey(paa => paa.ProcedureId);

            builder.Entity<ProcedureAnimalAid>()
                .HasOne(paa => paa.AnimalAid)
                .WithMany(paa => paa.AnimalAidProcedures)
                .HasForeignKey(paa => paa.AnimalAidId);

            builder.Entity<Vet>()
                .HasMany(v => v.Procedures)
                .WithOne(v => v.Vet)
                .HasForeignKey(v => v.VetId);
        }
    }
}
