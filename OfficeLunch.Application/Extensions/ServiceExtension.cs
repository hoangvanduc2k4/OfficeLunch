using Microsoft.Extensions.DependencyInjection;
using OfficeLunch.Application.Interfaces.Services;
using OfficeLunch.Application.Services;
using System.Reflection;

namespace OfficeLunch.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // 1. AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // 2. Services Injection
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
