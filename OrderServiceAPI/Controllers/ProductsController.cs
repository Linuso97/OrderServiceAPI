using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Products;
using OrderServiceAPI.Services;

namespace OrderServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _prodService;

        public ProductsController(IProductsService productsService)
        {
            _prodService = productsService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _prodService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProduct(int id)
        {
            var product = await _prodService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Product product, int id)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {
                await _prodService.UpdateProductAsync(product, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _prodService.ProductExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _prodService.AddProductAsync(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _prodService.DeleteProductAsync(id);

            var product = await _prodService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
