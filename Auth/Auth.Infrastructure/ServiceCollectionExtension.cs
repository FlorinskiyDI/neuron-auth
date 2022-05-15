using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString, string migrationsAssembly)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(migrationsAssembly);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                }));

            return services;
        }
    }
}
