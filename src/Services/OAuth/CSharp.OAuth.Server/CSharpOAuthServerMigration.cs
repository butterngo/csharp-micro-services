namespace CSharp.OAuth.Server
{
    using CSharp.OAuth.Server.Config;
    using CSharp.OAuth.Server.Constants;
    using CSharp.OAuth.Server.DbContext;
    using IdentityServer4.EntityFramework.DbContexts;
    using IdentityServer4.EntityFramework.Interfaces;
    using IdentityServer4.EntityFramework.Mappers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System.Linq;

    public class CSharpOAuthServerMigration
    {
        private readonly ConfigurationDbContext _configurationDbContext;

        private readonly IConfiguration _configuration;

        private readonly CSharpUserDbContext _csharpUserDbContext;

        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        private readonly ILogger<CSharpOAuthServerMigration> _logger;

        public CSharpOAuthServerMigration(ConfigurationDbContext configurationDbContext,
            CSharpUserDbContext csharpUserDbContext,
            IPasswordHasher<IdentityUser> passwordHasher,
            IConfiguration configuration,
            ILogger<CSharpOAuthServerMigration> logger) 
        {
            _configurationDbContext = configurationDbContext;

            _csharpUserDbContext = csharpUserDbContext;

            logger.LogInformation("Begin migration database.");

            _configurationDbContext.Database.Migrate();

            _csharpUserDbContext.Database.Migrate();

            logger.LogInformation("Migration database done.");

            _configuration = configuration;

            _passwordHasher = passwordHasher;

            _logger = logger;
        }

        public void InitData() 
        {
            _logger.LogInformation("Begin init data.");

            SeedIdentityResource();

            SeedScope();

            SeedClient();

            SeedUser();

            _logger.LogInformation("Init data done.");
        }

        public void SeedIdentityResource() 
        {
            if (!_configurationDbContext.IdentityResources.Any()) 
            {
                _configurationDbContext.IdentityResources.AddRange(GenerateIdentityResource.GetAll().Select(x => x.ToEntity()));

                _configurationDbContext.SaveChanges();
            }
        }

        public void SeedScope()
        {
            if (!_configurationDbContext.ApiResources.Any())
            {
                _configurationDbContext.ApiResources.AddRange(GenerateScopes.GetAll().Select(x => x.ToEntity()));

                _configurationDbContext.SaveChanges();
            }
        }

        public void SeedClient() 
        {
            if (!_configurationDbContext.Clients.Any())
            {
                string issuerUri = _configuration.GetValue<string>(AppSettingContants.Idsr4.IssuerUri);

                _configurationDbContext.Clients.AddRange(GenerateClient.GetAll(issuerUri).Select(x => x.ToEntity()));

                _configurationDbContext.SaveChanges();
            }
        }

        public void SeedUser() 
        {
            if (!_csharpUserDbContext.Users.Any()) 
            {
                var user = new IdentityUser 
                {
                    UserName = "admin@c-sharp.vn",
                    Email="admin@c-sharp.vn",
                    NormalizedUserName = "admin@c-sharp.vn".ToUpper(),
                    NormalizedEmail = "admin@c-sharp.vn".ToUpper()
                };

                user.PasswordHash = _passwordHasher.HashPassword(user, "admin");

                _csharpUserDbContext.Users.Add(user);

                _csharpUserDbContext.SaveChanges();
            }
        }
    }
}
