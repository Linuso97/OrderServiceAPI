using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.Data;
using OrderServiceAPI.Models.Customers;

namespace OrderServiceAPI.Services
{
    public class CustomerService : ICustomerService
    {
        readonly OrderServiceDbContext _context;
        public CustomerService(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(q => q.CustomerId == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> CustomerExists(int id)
        {
            return _context.Customers.AnyAsync(e => e.CustomerId == id);
        }
    }
}

