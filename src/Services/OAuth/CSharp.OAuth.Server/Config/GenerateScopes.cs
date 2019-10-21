namespace CSharp.OAuth.Server.Config
{
    using IdentityServer4.Models;
    using System.Collections.Generic;

    public class GenerateScopes
    {
        public static IEnumerable<ApiResource> GetAll()
        => new List<ApiResource> { new ApiResource("csharp-oauth-server", "CSharp OAuth Server") };
    }
}
