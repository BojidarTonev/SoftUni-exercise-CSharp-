using SoftJail.Data.Models;

namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;

	public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext() { }

		public SoftJailDbContext(DbContextOptions options)
			: base(options) { }


	    public DbSet<Cell> Cells { get; set; }
	    public DbSet<Department> Departments { get; set; }
	    public DbSet<Mail> Mails { get; set; }
	    public DbSet<Officer> Officers { get; set; }
	    public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
	    public DbSet<Prisoner> Prisoners { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
		    builder.Entity<OfficerPrisoner>()
		        .HasKey(e => new {e.OfficerId, e.PrisonerId});

		    builder.Entity<OfficerPrisoner>()
		        .HasOne(e => e.Prisoner)
		        .WithMany(e => e.PrisonerOfficers)
		        .HasForeignKey(e => e.PrisonerId);

		    builder.Entity<OfficerPrisoner>()
		        .HasOne(e => e.Officer)
		        .WithMany(e => e.OfficerPrisoners)
		        .HasForeignKey(e => e.OfficerId);

		    builder.Entity<Cell>()
		        .HasMany(e => e.Prisoners)
		        .WithOne(e => e.Cell)
		        .HasForeignKey(e => e.CellId);

		    builder.Entity<Department>()
		        .HasMany(e => e.Cells)
		        .WithOne(e => e.Department)
		        .HasForeignKey(e => e.DepartmentId);
		}
	}
}