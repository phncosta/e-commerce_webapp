using HeavensHall.Commerce.Application.Interfaces.Repository;
using HeavensHall.Commerce.Infrastructure.Data.Context;
using HeavensHall.Commerce.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HeavensHall.Commerce.Infrastructure.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            return services;
        }
    }
}
