using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext() { }

        public SalesContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode()
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode()
                    .IsRequired();

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasDefaultValue("No description");

            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.Property(e => e.Date)
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.ProductId)
                    .HasConstraintName("FK_Sales_Products")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Customer)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.CustomerId)
                    .HasConstraintName("FK_Sales_Customers")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Store)
                    .WithMany(e => e.Sales)
                    .HasForeignKey(e => e.StoreId)
                    .HasConstraintName("FK_Sales_Stores")
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode()
                    .IsRequired();
            });
        }
    }
}
