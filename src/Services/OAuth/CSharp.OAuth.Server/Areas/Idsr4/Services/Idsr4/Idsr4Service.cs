namespace CSharp.OAuth.Server.Idsr4.Services
{
    using CSharp.OAuth.Server.Areas.Idsr4;
    using CSharp.OAuth.Server.Areas.Idsr4.ViewModels;
    using CSharp.OAuth.Server.Constants;
    using CSharp.OAuth.Server.IdentityManager;
    using CSharp.OAuth.Server.Services;
    using IdentityModel.Client;
    using IdentityServer4.Models;
    using IdentityServer4.Services;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class Idsr4Service : IIdsr4Service
    {
        private readonly ILogger<Idsr4Service> _logger;

        private readonly CSharpUserManager _userManager;

        private readonly CSharpSignInManager _signInManager;

        public Idsr4Service(ILogger<Idsr4Service> logger,
            CSharpUserManager userManager,
            CSharpSignInManager signInManager) 
        {
            _logger = logger;

            _userManager = userManager;

            _signInManager = signInManager;
        }

        public async Task<IdentityUser> FindByUsernameAsync(string username)
        => await _userManager.FindByNameAsync(username);

        public async Task<ClaimsPrincipal> GenerateClaimsPrincipalAsync(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);

            return new ClaimsPrincipal(new ClaimsIdentity(claims));
        }
    }
}
