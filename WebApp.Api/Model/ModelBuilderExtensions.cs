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
        }
    }
}
