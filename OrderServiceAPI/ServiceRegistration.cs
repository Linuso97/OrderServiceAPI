using OrderServiceAPI.Services.Customers;
using OrderServiceAPI.Services.Orders;
using OrderServiceAPI.Services.Products;

namespace OrderServiceAPI
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IOrdersService, OrdersService>();
            return services;
        }
    }
}
