using OrderServiceAPI.Models.Orders;

namespace OrderServiceAPI.Services.Orders
{
    public interface IOrdersService
    {
        Task<Order> CreateOrderAsync(OrderRequest orderRequest);
    }
}