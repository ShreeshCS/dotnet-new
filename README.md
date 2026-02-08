# dotnet-new

## Overview

This is an ASP.NET Core Web API project for managing products and categories, using Entity Framework Core with a MySQL backend. The API supports CRUD operations for products and categories, including bulk upload and category-based queries.

## Project Structure

- `WebApp.Api/` - Main API project
	- `Controllers/` - API controllers for Products and Categories
	- `Model/` - Entity models and EF Core context
	- `DTOs/` - Data Transfer Objects for API requests and responses
	- `Database/`
		- `Scripts/StoredProcedures/` - SQL scripts for stored procedures
		- `DatabaseInitializer.cs` - Executes stored procedures at startup
	- `appsettings.json` - Configuration files
- `.postman/` and `postman/` - Postman collections and environments for API testing

## Key Features

- **Entity Framework Core** with MySQL provider (`Pomelo.EntityFrameworkCore.MySql`)
- **Product** and **Category** management with navigation properties
- **Bulk upload** endpoint for products
- **Stored procedures** for common queries (see `Database/Scripts/StoredProcedures`)
- **Swagger/OpenAPI** documentation enabled in development
- **DTO-based API** for clean separation of models and API contracts

## API Endpoints

- `GET /api/products` - List all products (with category info)
- `GET /api/products/{id}` - Get product by ID
- `GET /product-category/{id}` - Get products by category ID
- `POST /inventory/add/product` - Add a new product
- `POST /inventory/add/bulk-upload/products` - Bulk add products
- `GET /api/categories` - List all categories

## Known Issues

- After adding a product, the `Category` navigation property may be `null` unless explicitly loaded. Use `.Include(p => p.Category)` when querying products to ensure the category is populated. See [FutureEnhancements.md](WebApp.Api/FutureEnhancements.md) for details.

## Setup

1. **Configure MySQL**: Update the connection string in `appsettings.json`.
2. **Run the API**:  
	 ```sh
	 dotnet run --project WebApp.Api/WebApp.Api.csproj
	 ```
3. **Database Initialization**: Stored procedures are executed at startup via `DatabaseInitializer`.

## Development Notes

- See [asp-dotnet-notes.md](asp-dotnet-notes.md) for EF Core, context, and provider notes.
- Seeding is commented out in `ModelBuilderExtensions.cs` since MySQL is used.

## Testing

- Use the provided Postman collections in `.postman/` or `postman/collections/` for API testing.

---