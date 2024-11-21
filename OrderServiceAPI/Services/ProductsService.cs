using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Products;

namespace OrderServiceAPI.Services
{
    public class ProductsService : IProductsService
    {
        readonly OrderServiceDbContext _context;

        public ProductsService(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ActionResult<Product?>> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product, int id)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(q => q.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ProductExistsAsync(int id)
        {
            return await _context.Products.AnyAsync(e => e.ProductId == id);
        }
    }


}
