using SalesDatePrediction.Infrastructure.Repositories;
using SalesDatePrediction.Core.Interfaces;

namespace SalesDatePrediction.Api.Extensions
{
    internal static class StartupExtensionscs
    {
        public static WebApplicationBuilder CustomConfigureServices(this WebApplicationBuilder pBuilder)
        {
           
            pBuilder.Services.AddScoped<IProductRepository, ProductRepository>();

            pBuilder.Services.AddScoped<IShipperRepository, ShipperRepository >();

            pBuilder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            pBuilder.Services.AddScoped<IOrderRepository, OrderRepository>();

            pBuilder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            return pBuilder;
        }
    }
}
