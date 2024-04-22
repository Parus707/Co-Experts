using BusinessLogics.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Co_Expert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var Products = await _ProductService.GetAllProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var Product = await _ProductService.GetProductByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product Product)
        {
            await _ProductService.AddProductAsync(Product);
            return CreatedAtAction(nameof(GetProduct), new { id = Product.ProductId }, Product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Product Product)
        {
            if (id != Product.ProductId)
            {
                return BadRequest();
            }
            await _ProductService.UpdateProductAsync(Product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _ProductService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
