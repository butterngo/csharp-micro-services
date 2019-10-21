namespace CSharp.OAuth.Server.Idsr4.Services
{
    using CSharp.OAuth.Server.Areas.Idsr4.ViewModels;
    using Microsoft.AspNetCore.Identity;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IIdsr4Service
    {
        Task<IdentityUser> FindByUsernameAsync(string username);

        Task<ClaimsPrincipal> GenerateClaimsPrincipalAsync(IdentityUser user);

    }
}
