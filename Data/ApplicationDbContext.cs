using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Хлеб", Price = 10.99m, Stock = 50 },
                new Product { Id = 2, Name = "Молоко", Price = 15.99m, Stock = 30 },
                new Product { Id = 3, Name = "Онигири", Price = 8.99m, Stock = 100 },
                new Product { Id = 4, Name = "Антонова Анна", Price = 0m, Stock = 1 }
            );
        }
    }
}
