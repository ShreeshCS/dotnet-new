
# ASP.NET Core Web API Notes

## What is ORM?
ORM (Object-Relational Mapping) is a programming technique that allows developers to interact with a database using objects in their programming language instead of writing raw SQL queries. It maps database tables to classes and rows to objects, making data manipulation more intuitive and reducing boilerplate code. ORMs handle CRUD operations, relationships, and often support migrations and schema management. Examples include Entity Framework Core for .NET, Hibernate for Java, and Django ORM for Python.


## Entity Framework Core (EF Core)
- EF Core is an open-source ORM for .NET.
- Maps C# classes to database tables.
- Supports LINQ queries, migrations, and multiple databases.
- Used for data access in ASP.NET Core apps.

## EF Core In-Memory Package
- Package: `Microsoft.EntityFrameworkCore.InMemory`.
- Stores data in RAM (not a real database).
- Main uses:
  - Unit testing
  - Prototyping
- Data is lost when the app stops.
- Not all real database behaviors are supported.

## EF Core Database Providers
- EF Core supports many databases:
  - SQL Server
  - SQLite
  - PostgreSQL
  - MySQL (e.g., Pomelo.EntityFrameworkCore.MySql)
  - Oracle
  - Cosmos DB
- Install the appropriate provider and configure `DbContext`.

## Switching from In-Memory to MySQL
- No major issues switching from InMemory to MySQL.
- Steps:
  1. Install MySQL provider (e.g., Pomelo.EntityFrameworkCore.MySql).
  2. Update `DbContext` to use MySQL.
  3. Update connection string.
- Entity classes and most code remain unchanged.
- Test thoroughly, as some behaviors may differ between providers.


## What is context?
In Entity Framework Core, a context is like a bridge between your C# code and the database. It is a special class (usually based on `DbContext`) that lets you get data from the database and save changes back. You use the context to add, update, delete, or read records using simple C# code instead of SQL. For example, if you have a `Product` table, your context will have a `DbSet<Product>` property so you can work with products easily in your code.
