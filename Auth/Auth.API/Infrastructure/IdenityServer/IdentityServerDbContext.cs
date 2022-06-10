using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Infrastructure.IdenityServer
{
    public class IdentityServerDbContext : ConfigurationDbContext<IdentityServerDbContext>
    {
        public IdentityServerDbContext(
            DbContextOptions<IdentityServerDbContext> options,
            ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }
}
