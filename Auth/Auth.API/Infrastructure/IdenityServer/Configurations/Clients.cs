using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Auth.API.Infrastructure.IdenityServer.Configurations
{
    public class Clients
    {
        // client1 - spa app
        private static readonly string CLIENT_1_HOST_URL = "http://localhost:8001";
        private static readonly string CLIENT_1_NAME = "singleapp";
        private static readonly string CLIENT_1_ID = "singleapp";

        // client 2 - api service
        private static readonly string CLIENT_2_NAME = "api1";
        private static readonly string CLIENT_2_ID = "api1";
        private static readonly string CLIENT_2_SECRET = "secret";

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {

                new Client
                {
                    ClientId = "spaCodeClient",
                    ClientName = "SPA Code Client",
                    AccessTokenType = AccessTokenType.Jwt,
                    // RequireConsent = false,
                    AccessTokenLifetime = 3600,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 3600,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        $"{CLIENT_1_HOST_URL}/callback",
                        $"{CLIENT_1_HOST_URL}/silent-renew.html",
                        "https://localhost:4200",
                        "https://localhost:4200/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{CLIENT_1_HOST_URL}/unauthorized",
                        $"{CLIENT_1_HOST_URL}",
                        "https://localhost:4200/unauthorized",
                        "https://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{CLIENT_1_HOST_URL}",
                        "https://localhost:4200"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "resourceApi"
                    }
                },
                new Client
                {
                    ClientName = CLIENT_1_NAME,
                    ClientId = CLIENT_1_ID,
                    AccessTokenType = AccessTokenType.Reference,
                    AccessTokenLifetime = 3600,
                    AllowedGrantTypes = { "implicit", "password" },
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string> { CLIENT_1_HOST_URL, },
                    PostLogoutRedirectUris = new List<string> { CLIENT_1_HOST_URL, },
                    AllowedCorsOrigins = new List<string> { CLIENT_1_HOST_URL, },
                    AllowedScopes = { "openid", "api2"},
                },
                new Client
                {
                    ClientName = CLIENT_2_NAME,
                    ClientId = CLIENT_2_ID,
                    ClientSecrets = new List<Secret> { new Secret(CLIENT_2_SECRET.Sha256()), },
                    AllowedGrantTypes = { "implicit" },
                    AllowedScopes = new List<string> { "openid", "api2" },
                },
            };
        }
    }
}
