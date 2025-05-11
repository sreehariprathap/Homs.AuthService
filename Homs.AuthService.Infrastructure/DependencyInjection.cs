using Homs.AuthService.Application.Interfaces;
using Homs.AuthService.Infrastructure.Persistence;
using Homs.AuthService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Homs.AuthService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext with PostgreSQL
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Homs.AuthService.Infrastructure")));

            // Register infrastructure services
            services.AddScoped<IAuthService, Homs.AuthService.Infrastructure.Services.AuthService>(); // Fully qualify AuthService to avoid ambiguity


            return services;
        }
    }
}