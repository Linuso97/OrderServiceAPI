using OrderServiceAPI.Services;

namespace OrderServiceAPI
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductsService, ProductsService>();
            //services.AddScoped<IOrdersService, OrderService>();
            return services;
        }
    }
}
