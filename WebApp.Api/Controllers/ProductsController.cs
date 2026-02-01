using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Model;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound($"Product not found with id:{id}");
            }
            return Ok(product);
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
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            try
            {
                await _context.Products.AddAsync(product);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding product with id: " + product.Id);
            }
        }
    }
}
