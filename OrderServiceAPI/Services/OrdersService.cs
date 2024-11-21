using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Orders;

namespace OrderServiceAPI.Services
{
    public class OrdersService
    {
        readonly OrderServiceDbContext _context;
        public OrdersService(OrderServiceDbContext context)
        {
            _context = context;
        }
    }
}
