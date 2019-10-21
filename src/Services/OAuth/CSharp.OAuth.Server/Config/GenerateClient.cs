namespace CSharp.OAuth.Server.Config
{
    using IdentityServer4;
    using IdentityServer4.Models;
    using System.Collections.Generic;

    public class GenerateClient
    {
        public static IEnumerable<Client> GetAll(string clientUri)
        => new List<Client> 
        {
            new Client 
            {
                ClientId = "03c3d277-3f1f-456d-af6e-75f816094767",
                ClientName = "Csharp Viet Nam",
                AllowedGrantTypes = GrantTypes.Implicit,
                Description = "13bc95f9-f336-47d4-bc0a-debec4f2adbd",
                ClientSecrets = { new Secret("13bc95f9-f336-47d4-bc0a-debec4f2adbd".Sha256()) },
                RedirectUris =           { $"http://localhost:5050/signin-oidc" },
                PostLogoutRedirectUris = { $"http://localhost:5050/signout-callback-oidc" },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "csharp-oauth-server"
                },
                AllowOfflineAccess = true
            }
        };
    }
}
