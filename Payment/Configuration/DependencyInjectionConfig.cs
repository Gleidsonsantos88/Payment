using Microsoft.Extensions.DependencyInjection;
using PaymentRepository.Repository;
using PaymentService.Intefaces;
using PaymentService.Services;

namespace Payment.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ISaleService, SaleService>();

            return services;
        }
    }
}
