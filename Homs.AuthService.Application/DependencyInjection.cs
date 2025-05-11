using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Homs.AuthService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add any other application services here

            return services;
        }
    }
}