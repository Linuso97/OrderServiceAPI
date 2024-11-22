using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Orders;

namespace OrderServiceAPI.Services.Orders
{
    public class OrdersService
    {
        readonly OrderServiceDbContext _context;
        public OrdersService(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order, List<OrderItem> orderItems)
        {
            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            decimal totalAmount = 0;

            foreach (var item in orderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);

                if(product == null)
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

                totalAmount += item.Quantity * item.UnitPrice;                
            }

            newOrder.TotalAmount = totalAmount;
            await _context.SaveChangesAsync();
            return newOrder;
        }
}
}
