using System;

namespace WebApp.Api.DTOs.CreateUpdateDtos;

public class CreateProductDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }
    public required int CategoryId { get; set; }
}
