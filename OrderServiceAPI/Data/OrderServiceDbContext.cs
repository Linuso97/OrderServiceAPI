using Microsoft.EntityFrameworkCore;

namespace OrderServiceAPI.Data
{
    public class OrderServiceDbContext : DbContext
    {
        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options) : base(options)
        {
            
        }

    }
}
