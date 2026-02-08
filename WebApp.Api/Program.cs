using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WebApp.Api.Model;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
// builder.Services.AddDbContext<ShopContext>(options =>
//     options.UseInMemoryDatabase("ShopDb"));

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Execute stored procedure scripts at startup
WebApp.Api.Database.DatabaseInitializer.ExecuteStoredProcedures(
    connectionString,
    Path.Combine(builder.Environment.ContentRootPath, "Database", "Scripts", "StoredProcedures")
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
