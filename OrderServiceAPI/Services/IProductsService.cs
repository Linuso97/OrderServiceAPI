using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.Models.Products;

namespace OrderServiceAPI.Services
{
    public interface IProductsService
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync();
        Task<ActionResult<Product?>> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product, int id);
        Task<bool> ProductExistsAsync(int id);
    }
}