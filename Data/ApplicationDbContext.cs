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
            base.OnModelCreating(modelBuilder);

            // Добавляем начальные данные
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Молоко", Price = 9.99m, Stock = 100 },
                new Product { Id = 2, Name = "Хлеб", Price = 19.99m, Stock = 50 }
            );
        }
    }
}
