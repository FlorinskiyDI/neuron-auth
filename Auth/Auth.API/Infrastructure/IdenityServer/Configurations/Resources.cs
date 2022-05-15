using System.Collections.Generic;
using IdentityServer4.Models;

namespace Auth.API.Infrastructure.IdenityServer.Configurations
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceApi", "API Application")
            };
        }
    }
}
