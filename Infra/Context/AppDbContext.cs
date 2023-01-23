using Domain.Entities;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ProductStatus>().HasNoKey();
            modelBuilder.Ignore<ProductStatus>();
            
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Provider)
                .WithOne(p => p.Product)
                .HasForeignKey<Provider>(p => p.ProductId);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
        }

        public DbSet<Product> Products { get; set; }
    }
}
