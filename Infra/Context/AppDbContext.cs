﻿using Domain.Entities;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(new ProductMap().Configure);
        }

        public DbSet<Product> Products { get; set; }
    }
}
