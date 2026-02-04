using System;

namespace WebApp.Api.DTOs.ReadDtos;

public class ReadCategoryDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
}
