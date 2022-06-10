using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Auth.API.Infrastructure.IdenityServer.Configurations
{
    public class Clients
    {
        // client1 - spa app
        private static readonly string CLIENT_1_HOST_URL = "http://localhost:4200";
        private static readonly string CLIENT_1_NAME = "Angular-Client";
        private static readonly string CLIENT_1_ID = "angular-client";


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
               {
                   ClientName = CLIENT_1_NAME,
                   ClientId = CLIENT_1_ID,
                   AllowedGrantTypes = GrantTypes.Code,
                   RedirectUris = new List<string>{ $"{CLIENT_1_HOST_URL}/signin-callback", $"{CLIENT_1_HOST_URL}/assets/silent-callback.html" },
                   RequirePkce = true,
                   AllowAccessTokensViaBrowser = true,
                   AllowedScopes =
                   {
                       IdentityServerConstants.StandardScopes.OpenId,
                       IdentityServerConstants.StandardScopes.Profile
                   },
                   AllowedCorsOrigins = { CLIENT_1_HOST_URL },
                   RequireClientSecret = false,
                   PostLogoutRedirectUris = new List<string> { $"{CLIENT_1_HOST_URL}///signout-callback" },
                   RequireConsent = false,
                   AccessTokenLifetime = 120
               }
            };
        }
    }
}
