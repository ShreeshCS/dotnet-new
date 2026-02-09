namespace WebApp.Api.DTOs.ReadDtos
{
    public class ReadProductDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public required ReadCategoryDto Category { get; set; }
    }
}

