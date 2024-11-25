using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Orders;

namespace OrderServiceAPI.Services.Orders
{
    public class OrdersService : IOrdersService
    {
        readonly OrderServiceDbContext _context;
        public OrdersService(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(OrderRequest orderRequest)
        {
            await CustomerExistsAsync(orderRequest);

            var newOrder = new Order
            {
                CustomerId = orderRequest.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            decimal totalAmount = 0;

            foreach (var item in orderRequest.Items)
            {
                var product = await _context.Products.FindAsync(item.ProductId);

                if (product == null)
                {
                    throw new Exception($"Product with ID {item.ProductId} not found.");
                }

                var orderItem = new OrderItem
                {
                    OrderId = newOrder.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };
                await _context.AddAsync(orderItem);

                totalAmount += item.Quantity * product.Price;
            }

            newOrder.TotalAmount = totalAmount;
            await _context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<ActionResult<Order?>> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(q => q.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CustomerExistsAsync(OrderRequest orderRequest)
        {
            var customerExists = await _context.Customers.AnyAsync(q => q.CustomerId == orderRequest.CustomerId);
            if (!customerExists)
            {
                throw new Exception($"Customer with ID {orderRequest.CustomerId} not found.");
            }
        }
    }
}
