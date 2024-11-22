using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.Models.Products;

namespace OrderServiceAPI.Services.Products
{
    public interface IProductsService
    {
        Task<Product> AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<ActionResult<IEnumerable<Product>>> GetProductsAsync();
        Task<ActionResult<Product?>> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product, int id);
        Task<bool> ProductExistsAsync(int id);
    }
}