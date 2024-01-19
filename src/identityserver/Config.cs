using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace identityserver;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource()
            {
                Name = "verification",
                UserClaims = new List<string>
                {
                    JwtClaimTypes.Email,
                    JwtClaimTypes.EmailVerified,
                    JwtClaimTypes.Role
                },
            }
        };
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope(name: "api1", displayName:"MyAPI", new List<string>{"role"})
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client()
                {
                    ClientId = "web",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256()),
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "verification",
                        "api1"
                    },
                    AllowOfflineAccess = true,
                }
            };
}