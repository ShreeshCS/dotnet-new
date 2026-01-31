using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Model;

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
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound($"Product not found with id:{id}");
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("/product-category/{id:int}")]
        public ActionResult<IEnumerable<Product>> GetProductsByCategoryId(int id)
        {
            var products = _context.Products.Where(p => p.CategoryId == id);
            return products.ToList();
        }
    }
}
