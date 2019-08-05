using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Auth.Config
{
    public static class IdentityConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("CoreApi", "Mi Aplicacion API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients(
            IConfiguration configuration
        )
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = configuration.GetValue<string>("Client:ClientId"),
                    ClientName = "",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = false,

                    ClientSecrets =
                    {
                        new Secret(configuration.GetValue<string>("Client:SecretKey").Sha256())
                    },

                    RedirectUris           = {$""},
                    PostLogoutRedirectUris = {$""},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CoreApi",
                    },

                    AllowOfflineAccess = true,

                    //envia el token por defecto
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }
    }
}
