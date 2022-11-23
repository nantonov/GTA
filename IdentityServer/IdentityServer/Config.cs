using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("AirlineTicketsAPI"),
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("AirlineTicketsAPI", "AirlineTickets API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client_id_swagger",
                    ClientSecrets = { new Secret("client_secret_swagger".ToSha256()) },
                    AllowedGrantTypes =  GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:7060" },
                    AllowedScopes =
                    {
                        "AirlineTicketsAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },

                new Client
                {
                    ClientId = "client_id_react",
                    ClientName = "React app client",
                    ClientUri = "http://localhost:3000",
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedCorsOrigins = {"http://localhost:3000"},
                    RedirectUris = { "http://localhost:3000/callback", "http://localhost:3000/refresh" },
                    PostLogoutRedirectUris = { "http://localhost:3000/logout" },
                    AllowOfflineAccess = true,
                    AllowedScopes =
                    {
                        "AirlineTicketsAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
    }
}