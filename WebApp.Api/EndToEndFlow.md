# End-to-End Flow Documentation for WebApp.Api

## 1. Models
- **Purpose:** Represent database entities in C#.
- **Files:**
  - Model/Product.cs: Product entity, includes navigation property to Category.
  - Model/Category.cs: Category entity, includes collection of products.
  - Model/ShopContext.cs: EF Core DbContext bridging C# code and database.

## 2. DTOs (Data Transfer Objects)
- **Purpose:** Define API request/response shapes, separate from internal models.
- **Files:**
  - DTOs/CreateUpdateDtos/CreateProductDto.cs: Used for product creation (POST endpoints).
  - DTOs/ReadDtos/ReadProductDto.cs: Used for product responses, includes category info.
  - DTOs/ReadDtos/ReadCategoryDto.cs: Used for category responses.

## 3. Database Connection
- **Configuration:**
  - Connection string in appsettings.json.
  - Registered in Program.cs using MySQL provider (Pomelo.EntityFrameworkCore.MySql).
- **Initialization:**
  - Database/DatabaseInitializer.cs: Executes stored procedure scripts at startup.

## 4. Stored Procedures
- **Purpose:** Encapsulate SQL logic for queries and inserts.
- **Location:** Database/Scripts/StoredProcedures/

## 5. Controllers & Endpoints
- **ProductsController:**
  - GET /api/products: Returns all products with category info.
  - GET /api/products/{id}: Returns product by ID.
  - GET /product-category/{id}: Returns products by category.
  - POST /inventory/add/product: Adds a new product.
  - POST /inventory/add/bulk-upload/products: Bulk adds products.
- **CategoriesController:**
  - GET /api/categories: Returns all categories.

## 6. Flow Example: Adding and Retrieving a Product
1. Client sends POST request to /inventory/add/product with a CreateProductDto.
2. Controller receives DTO, executes stored procedure to insert product.
3. Product is stored in MySQL database with CategoryId.
4. Client sends GET request to /api/products.
5. Controller executes stored procedure, joins product and category tables, returns list of ReadProductDto (with category info).
6. Client receives response: Each product includes its category via ReadCategoryDto.

## 7. Notes & Known Issues
- Navigation properties (e.g., Product.Category) are not auto-populated after insert; must use .Include() or join in stored procedures for retrieval.
- DTOs ensure API contracts are stable and decoupled from internal models.

## 8. Testing
- Use Postman collections in postman/collections/ for API testing.

---

**Summary:**
- Models represent database entities.
- DTOs define API request/response shapes.
- Controllers handle HTTP requests, map DTOs to models, and interact with the database via EF Core and stored procedures.
- Stored procedures encapsulate SQL logic.
- Database connection is configured in appsettings.json and registered in Program.cs.
- API endpoints provide CRUD and bulk operations for products and categories, always returning DTOs for clean separation.
