using Microsoft.EntityFrameworkCore;

namespace WebApp.Api.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Active Wear - Men" },
                new Category { Id = 2, Name = "Active Wear - Women" },
                new Category { Id = 3, Name = "Mineral Water" },
                new Category { Id = 4, Name = "Publications" },
                new Category { Id = 5, Name = "Supplements" });
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Men's Running Shorts", Price = 29.99m, Description = "Lightweight shorts for running.", CategoryId = 1 },
                new Product { Id = Guid.NewGuid(), Name = "Men's Training T-Shirt", Price = 19.99m, Description = "Breathable t-shirt for workouts.", CategoryId = 1 },
                new Product { Id = Guid.NewGuid(), Name = "Men's Track Jacket", Price = 49.99m, Description = "Comfortable jacket for outdoor activities.", CategoryId = 1 },
                new Product { Id = Guid.NewGuid(), Name = "Women's Yoga Pants", Price = 34.99m, Description = "Stretchable yoga pants for women.", CategoryId = 2 },
                new Product { Id = Guid.NewGuid(), Name = "Women's Sports Bra", Price = 24.99m, Description = "Supportive sports bra.", CategoryId = 2 },
                new Product { Id = Guid.NewGuid(), Name = "Women's Running Shoes", Price = 69.99m, Description = "Cushioned shoes for running.", CategoryId = 2 },
                new Product { Id = Guid.NewGuid(), Name = "Spring Mineral Water 500ml", Price = 1.49m, Description = "Pure spring mineral water.", CategoryId = 3 }
            );
        }
    }
}
