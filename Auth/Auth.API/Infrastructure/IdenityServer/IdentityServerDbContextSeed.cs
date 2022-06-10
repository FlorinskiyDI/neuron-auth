using Auth.API.Infrastructure.IdenityServer.Configurations;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Infrastructure.IdenityServer
{
    public static class IdentityServerDbContextSeed
    {
        public static async Task<WebApplication> SeedIdentityServer(this WebApplication app)
        {
            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<IdentityServerDbContext>();
                    context.Database.Migrate();

                    if (!context.Clients.Any())
                    {
                        foreach (var client in Clients.GetClients())
                        {
                            context.Clients.Add(client.ToEntity());
                        }

                        await context.SaveChangesAsync();
                    }

                    if (!context.IdentityResources.Any())
                    {
                        foreach (var resource in Resources.GetIdentityResources())
                        {
                            context.IdentityResources.Add(resource.ToEntity());
                        }

                        await context.SaveChangesAsync();
                    }

                    if (!context.ApiResources.Any())
                    {
                        foreach (var resource in Resources.GetApiResources())
                        {
                            context.ApiResources.Add(resource.ToEntity());
                        }

                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during identity server seed");
            }

            return app;
        }
    }
}
