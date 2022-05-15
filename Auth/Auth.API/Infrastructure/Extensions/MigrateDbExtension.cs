using Auth.API.Infrastructure.IdenityServer;
using Auth.API.Infrastructure.Identity;
using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Infrastructure.Extensions
{
    public static class MigrateDbExtension
    {
        public async static Task<WebApplication> MigrateDb(this WebApplication app)
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var identityServerDbContext = scope.ServiceProvider.GetRequiredService<IdentityServerDbContext>();
                    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    identityServerDbContext.Database.Migrate();
                    applicationDbContext.Database.Migrate();
                }

                await app.SeedIdentity();
                await app.SeedIdentityServer();

            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during migrations");
            }

            return app;
        }
    }
}
