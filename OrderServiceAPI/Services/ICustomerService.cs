using Microsoft.AspNetCore.Mvc;
using OrderServiceAPI.Models.Customers;

namespace OrderServiceAPI.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync();
        Task UpdateCustomerAsync(int id, Customer customer);
        Task<bool> CustomerExists(int id);
    }
}