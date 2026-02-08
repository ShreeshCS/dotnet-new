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
                new Category { Id = 5, Name = "Supplements" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Men's Running Shorts",
                    Price = 29.99m,
                    Description = "Lightweight, breathable shorts for men. Perfect for running and gym workouts.",
                    CategoryId = 1
                },
                new Product
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Women's Yoga Leggings",
                    Price = 39.99m,
                    Description = "High-waisted leggings for women. Ideal for yoga, pilates, and everyday wear.",
                    CategoryId = 2
                },
                new Product
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Spring Mineral Water (1L)",
                    Price = 1.99m,
                    Description = "Pure spring mineral water, bottled at the source. Refreshing and healthy.",
                    CategoryId = 3
                },
                new Product
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Fitness Magazine - Jan 2026",
                    Price = 5.99m,
                    Description = "Latest edition of Fitness Magazine. Includes tips, workouts, and nutrition advice.",
                    CategoryId = 4
                },
                new Product
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Vitamin D3 Supplement",
                    Price = 14.99m,
                    Description = "Vitamin D3 tablets for daily health. Supports bone and immune system.",
                    CategoryId = 5
                }
            );
        }
    }
}
