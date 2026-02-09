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
            var result = new List<ReadProductDto>();
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetAllProducts";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new ReadProductDto
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = new ReadCategoryDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                            }
                        });
                    }
                }
            }
            await conn.CloseAsync();
            return Ok(result);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var result = new ReadProductDto
            {
                Name = string.Empty,
                Category = new ReadCategoryDto
                {
                    Id = 0,
                    Name = string.Empty
                }
            };
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetProductById";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var param = cmd.CreateParameter();
                param.ParameterName = "productId";
                param.Value = id.ToString();
                param.DbType = System.Data.DbType.String;
                cmd.Parameters.Add(param);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result = new ReadProductDto
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = new ReadCategoryDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                            }
                        };
                    }
                }
            }

            await conn.CloseAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("/product-category/{id:int}")]
        public async Task<ActionResult<IEnumerable<ReadProductDto>>> GetProductsByCategoryId(int id)
        {
            var result = new List<ReadProductDto>();
            var conn = _context.Database.GetDbConnection();
            await conn.OpenAsync();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "GetProductsByCategoryId";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var param = cmd.CreateParameter();
                param.ParameterName = "categoryId";
                param.Value = id;
                param.DbType = System.Data.DbType.Int32;
                cmd.Parameters.Add(param);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new ReadProductDto
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Category = new ReadCategoryDto
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                                Name = reader.GetString(reader.GetOrdinal("CategoryName"))
                            }
                        });
                    }
                }
            }
            await conn.CloseAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("/inventory/add/product")]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto dto)
        {
            if (dto is null)
                return BadRequest();

            try
            {
                var conn = _context.Database.GetDbConnection();
                await conn.OpenAsync();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AddProduct";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var nameParam = cmd.CreateParameter();
                    nameParam.ParameterName = "name";
                    nameParam.Value = dto.Name;
                    nameParam.DbType = System.Data.DbType.String;
                    cmd.Parameters.Add(nameParam);

                    var priceParam = cmd.CreateParameter();
                    priceParam.ParameterName = "price";
                    priceParam.Value = dto.Price;
                    priceParam.DbType = System.Data.DbType.Decimal;
                    cmd.Parameters.Add(priceParam);

                    var descriptionParam = cmd.CreateParameter();
                    descriptionParam.ParameterName = "description";
                    descriptionParam.Value = dto.Description;
                    descriptionParam.DbType = System.Data.DbType.String;
                    cmd.Parameters.Add(descriptionParam);

                    var categoryIdParam = cmd.CreateParameter();
                    categoryIdParam.ParameterName = "categoryId";
                    categoryIdParam.Value = dto.CategoryId;
                    categoryIdParam.DbType = System.Data.DbType.Int32;
                    cmd.Parameters.Add(categoryIdParam);

                    await cmd.ExecuteNonQueryAsync();
                }
                await conn.CloseAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while adding product " + ex.Data.ToString());
            }
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
                var conn = _context.Database.GetDbConnection();
                await conn.OpenAsync();

                foreach (var dto in productDto)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "AddProduct";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        var nameParam = cmd.CreateParameter();
                        nameParam.ParameterName = "name";
                        nameParam.Value = dto.Name;
                        nameParam.DbType = System.Data.DbType.String;
                        cmd.Parameters.Add(nameParam);

                        var priceParam = cmd.CreateParameter();
                        priceParam.ParameterName = "price";
                        priceParam.Value = dto.Price;
                        priceParam.DbType = System.Data.DbType.Decimal;
                        cmd.Parameters.Add(priceParam);

                        var descriptionParam = cmd.CreateParameter();
                        descriptionParam.ParameterName = "description";
                        descriptionParam.Value = dto.Description;
                        descriptionParam.DbType = System.Data.DbType.String;
                        cmd.Parameters.Add(descriptionParam);

                        var categoryIdParam = cmd.CreateParameter();
                        categoryIdParam.ParameterName = "categoryId";
                        categoryIdParam.Value = dto.CategoryId;
                        categoryIdParam.DbType = System.Data.DbType.Int32;
                        cmd.Parameters.Add(categoryIdParam);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                await conn.CloseAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while running bulk upload " + ex.Data.ToString());
            }
            return Ok();
        }
    }
}
