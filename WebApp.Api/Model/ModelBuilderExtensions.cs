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
                new Product { Id = 1, Name = "Men's Running Shorts", Price = 29.99m, Description = "Lightweight shorts for running.", CategoryId = 1, Category = null },
                new Product { Id = 2, Name = "Men's Training T-Shirt", Price = 19.99m, Description = "Breathable t-shirt for workouts.", CategoryId = 1, Category = null },
                new Product { Id = 3, Name = "Men's Track Jacket", Price = 49.99m, Description = "Comfortable jacket for outdoor activities.", CategoryId = 1, Category = null },
                new Product { Id = 4, Name = "Women's Yoga Pants", Price = 34.99m, Description = "Stretchable yoga pants for women.", CategoryId = 2, Category = null },
                new Product { Id = 5, Name = "Women's Sports Bra", Price = 24.99m, Description = "Supportive sports bra.", CategoryId = 2, Category = null },
                new Product { Id = 6, Name = "Women's Running Shoes", Price = 69.99m, Description = "Cushioned shoes for running.", CategoryId = 2, Category = null },
                new Product { Id = 7, Name = "Spring Mineral Water 500ml", Price = 1.49m, Description = "Pure spring mineral water.", CategoryId = 3, Category = null },
                new Product { Id = 8, Name = "Spring Mineral Water 1L", Price = 2.49m, Description = "1 liter bottle of mineral water.", CategoryId = 3, Category = null },
                new Product { Id = 9, Name = "Sparkling Mineral Water 500ml", Price = 1.79m, Description = "Sparkling mineral water.", CategoryId = 3, Category = null },
                new Product { Id = 10, Name = "Fitness Magazine - June Edition", Price = 5.99m, Description = "Latest fitness trends and tips.", CategoryId = 4, Category = null },
                new Product { Id = 11, Name = "Healthy Living Guidebook", Price = 14.99m, Description = "Comprehensive guide to healthy living.", CategoryId = 4, Category = null },
                new Product { Id = 12, Name = "Yoga for Beginners Book", Price = 9.99m, Description = "Step-by-step yoga instructions.", CategoryId = 4, Category = null },
                new Product { Id = 13, Name = "Whey Protein Powder 1kg", Price = 39.99m, Description = "High-quality whey protein.", CategoryId = 5, Category = null },
                new Product { Id = 14, Name = "Multivitamin Tablets", Price = 12.99m, Description = "Daily multivitamin supplement.", CategoryId = 5, Category = null },
                new Product { Id = 15, Name = "Omega-3 Fish Oil", Price = 16.99m, Description = "Supports heart and brain health.", CategoryId = 5, Category = null },
                new Product { Id = 16, Name = "Men's Compression Socks", Price = 14.99m, Description = "Improves blood circulation.", CategoryId = 1, Category = null },
                new Product { Id = 17, Name = "Women's Fitness Tank Top", Price = 21.99m, Description = "Lightweight tank top for workouts.", CategoryId = 2, Category = null },
                new Product { Id = 18, Name = "Electrolyte Water 500ml", Price = 2.29m, Description = "Hydrating electrolyte water.", CategoryId = 3, Category = null },
                new Product { Id = 19, Name = "Fitness Magazine - July Edition", Price = 5.99m, Description = "Monthly fitness magazine.", CategoryId = 4, Category = null },
                new Product { Id = 20, Name = "Vitamin C Tablets", Price = 8.99m, Description = "Boosts immune system.", CategoryId = 5, Category = null }
            );
        }
    }
}
