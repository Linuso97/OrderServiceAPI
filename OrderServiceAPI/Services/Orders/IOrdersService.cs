using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.Models.Orders;

namespace OrderServiceAPI.Services.Orders
{
    public interface IOrdersService
    {
        Task<Order> CreateOrderAsync(OrderRequest orderRequest);
        Task<ActionResult<IEnumerable<Order>>> GetOrdersAsync();
        Task<ActionResult<Order?>> GetOrderByIdAsync(int id);
        Task DeleteOrderAsync(int id);
    }
}