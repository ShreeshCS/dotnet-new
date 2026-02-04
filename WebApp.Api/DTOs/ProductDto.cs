using System;

namespace WebApp.Api.DTOs;

public class ProductDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }
    public int CategoryId { get; set; }
}
