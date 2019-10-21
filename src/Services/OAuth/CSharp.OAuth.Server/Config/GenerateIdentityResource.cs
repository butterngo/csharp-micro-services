namespace CSharp.OAuth.Server.Config
{
    using IdentityServer4.Models;
    using System.Collections.Generic;

    public class GenerateIdentityResource
    {
        public static IEnumerable<IdentityResource> GetAll()
        => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
            };
    }
}
