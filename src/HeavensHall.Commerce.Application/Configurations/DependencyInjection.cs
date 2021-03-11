using HeavensHall.Commerce.Application.Interfaces.Service;
using HeavensHall.Commerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HeavensHall.Commerce.Application.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
