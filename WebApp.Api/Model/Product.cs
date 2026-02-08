using System;
using System.Text.Json.Serialization;

namespace WebApp.Api.Model;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }
    public required int CategoryId { get; set; }
    public Category? Category { get; set; }
}
