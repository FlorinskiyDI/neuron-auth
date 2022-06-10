using Auth.Domain.Entities;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace Auth.API.Infrastructure.IdenityServer.Configurations
{
    public class CustomProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomProfileService(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = _userManager.FindByIdAsync(sub).Result;

            //var user = InMemoryConfig.GetUsers()
            //    .Find(u => u.SubjectId.Equals(sub));

            //context.IssuedClaims.AddRange(user.Claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = _userManager.FindByIdAsync(sub).Result;
            //var user = InMemoryConfig.GetUsers()
            //    .Find(u => u.SubjectId.Equals(sub));

            context.IsActive = user != null;
            return Task.CompletedTask;
        }
    }
}
