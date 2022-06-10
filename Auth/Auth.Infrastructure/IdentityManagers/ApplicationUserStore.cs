using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.IdentityManagers
{
    public class ApplicationUserStore : UserStore<ApplicationUser, IdentityRole<Guid>, ApplicationDbContext, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>
    {
        public ApplicationUserStore(
            ApplicationDbContext context,
            IdentityErrorDescriber? errorDescriber = null)
            : base(context, errorDescriber)
        {
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            ThrowIfDisposed();
            user = user ?? throw new ArgumentNullException(nameof(user));

            Context.Remove(user);
            await Context.SaveChangesAsync();
        }

        public async Task<ApplicationUser?> FindByEmailAsync(string email, bool checkDeletedEntities)
        {
            checkDeletedEntities = false;
            return checkDeletedEntities
                ? await Context.Users.IgnoreQueryFilters().Where(u => u.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync()
                : await Context.Users.Where(u => u.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync();
        }
    }
}
