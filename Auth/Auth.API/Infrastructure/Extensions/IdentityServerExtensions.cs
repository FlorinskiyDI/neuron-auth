using Auth.API.Infrastructure.IdenityServer;
using Auth.Domain.Entities;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Infrastructure.Extensions
{
    public static class IdentityServerExtensions
    {
        public static IServiceCollection AddAppIdentityServer(
            this IServiceCollection services,
            string connectionString,
            string migrationsAssembly)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
               .AddAspNetIdentity<ApplicationUser>()
               ////.AddTemporarySigningCredential()
               .AddConfigurationStore<IdentityServerDbContext>(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseSqlServer(
                       connectionString,
                       sqlServerOptionsAction: sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly(migrationsAssembly);
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
               })
               .AddOperationalStore<PersistedGrantDbContext>(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseSqlServer(
                       connectionString,
                       sqlServerOptionsAction: sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly(migrationsAssembly);
                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                       });
               });

            return services;
        }

        public static IApplicationBuilder UseAppIdentityServer(this IApplicationBuilder app)
        {
            app.UseIdentityServer();

            return app;
        }
    }
}

