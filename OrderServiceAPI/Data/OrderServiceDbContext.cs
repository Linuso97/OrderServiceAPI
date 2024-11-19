using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Models.Customers;
using OrderServiceAPI.Models.Orders;
using OrderServiceAPI.Models.Products;

namespace OrderServiceAPI.Data
{
    public class OrderServiceDbContext : DbContext
    {
        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
