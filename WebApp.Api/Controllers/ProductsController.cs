using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Model;
using Microsoft.EntityFrameworkCore;
using WebApp.Api.DTOs;
using WebApp.Api.DTOs.ReadDtos;
using WebApp.Api.DTOs.CreateUpdateDtos;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;
        public ProductsController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadProductDto>>> GetAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            var result = products.Select(p => new ReadProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Category = p.Category == null
                    ? throw new InvalidOperationException($"Category not found for product with id: {p.Id}")
                    : new ReadCategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    },
            });

            return Ok(result);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound($"Product not found with id:{id}");
            }
            return Ok(new ReadProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category == null
                    ? throw new InvalidOperationException($"Category not found for product with id: {id}")
                    : new ReadCategoryDto
                    {
                        Id = product.Category.Id,
                        Name = product.Category.Name
                    }
            });
        }

        [HttpGet]
        [Route("/product-category/{id:int}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategoryId(int id)
        {
            var products = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        [Route("/inventory/add/product")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto dto)
        {
            if (dto is null)
                return BadRequest();

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Category = await _context.Categories.FindAsync(dto.CategoryId) ?? throw new InvalidOperationException($"Category not found with id: {dto.CategoryId}")
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("/inventory/add/bulk-upload/products")]
        public async Task<IActionResult> BulkAddProducts([FromBody] List<CreateProductDto> productDto)
        {
            if (productDto is null)
                return BadRequest();

            try
            {
                foreach (var p in productDto)
                {
                    var product = new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = p.Name,
                        Price = p.Price,
                        Description = p.Description,
                        CategoryId = p.CategoryId,
                        Category = await _context.Categories.FindAsync(p.CategoryId) ?? throw new InvalidOperationException($"Category not found with id: {p.CategoryId}")
                    };

                    await _context.AddAsync(product);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while running bulk upload " + ex.Data.ToString());
            }
            return Ok();
        }
    }
}
