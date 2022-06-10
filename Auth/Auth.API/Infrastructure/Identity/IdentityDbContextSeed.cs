using Auth.Domain.Entities;
using Auth.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Infrastructure.Identity
{
    public static class IdentityDbContextSeed
    {
        private const string Email = "super-admin@gmail.com";
        private const string Password = "SuperAdmin";

        public static async Task<WebApplication> SeedIdentity(this WebApplication app)
        {
            var user = new ApplicationUser()
            {
                Email = Email,
                UserName = Email
            };

            try
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                await userManager.CreateAsync(user, Password);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during identity seed");
            }

            return app;
        }
    }
}
