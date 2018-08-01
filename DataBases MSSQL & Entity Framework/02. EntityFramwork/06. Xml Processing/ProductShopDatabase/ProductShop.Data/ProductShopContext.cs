using System;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data.Configurations;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext() { }

        public ProductShopContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryProductsConfiguration());
        }
    }
}
