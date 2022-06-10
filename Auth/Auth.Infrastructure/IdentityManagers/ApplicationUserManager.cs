using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auth.Infrastructure.IdentityManagers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly ApplicationUserStore _applicationUserStore;

        public ApplicationUserManager(
            UserStore<
                ApplicationUser,
                IdentityRole<Guid>,
                ApplicationDbContext,
                Guid, IdentityUserClaim<Guid>,
                IdentityUserRole<Guid>,
                IdentityUserLogin<Guid>,
                IdentityUserToken<Guid>,
                IdentityRoleClaim<Guid>> userStore,
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _applicationUserStore = userStore as ApplicationUserStore;
        }

        public async override Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            CancellationToken token = new(false);
            await _applicationUserStore.DeleteAsync(user, token);

            return IdentityResult.Success;
        }

        public async Task<ApplicationUser?> FindByEmailAsync(string email, bool checkDeletedEntities)
        {
            email = email ?? throw new ArgumentNullException(nameof(email));
            return await _applicationUserStore.FindByEmailAsync(email, checkDeletedEntities);
        }
    }
}
