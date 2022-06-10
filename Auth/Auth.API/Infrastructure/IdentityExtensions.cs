using Auth.Domain.Entities;
using Auth.Infrastructure;
using Auth.Infrastructure.IdentityManagers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Auth.API.Infrastructure
{
    public static class IdentityExtensions
    {
        public static IServiceCollection AddAppIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 4;
                })
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddScoped<UserStore<ApplicationUser, IdentityRole<Guid>, ApplicationDbContext, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>, ApplicationUserStore>();
            services.AddScoped<UserManager<ApplicationUser>, ApplicationUserManager>();

            return services;
        }
    }
}
