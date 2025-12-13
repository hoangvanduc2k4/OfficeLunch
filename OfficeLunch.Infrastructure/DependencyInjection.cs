using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeLunch.Infrastructure.Persistence;

namespace OfficeLunch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<OfflineLunchDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Đăng ký các Repository khác (nếu có)
            // services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
