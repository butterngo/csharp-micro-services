namespace CSharp.OAuth.Server.Extensions
{
    using CSharp.OAuth.Server.Constants;
    using CSharp.OAuth.Server.DbContext;
    using CSharp.OAuth.Server.IdentityManager;
    using CSharp.OAuth.Server.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class Idsr4Extension
    {
        public static IServiceCollection AddIdsr4(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(AppSettingContants.Sql.Connectionstring);

            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<CSharpUserDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddUserManager<CSharpUserManager>()
                    .AddSignInManager<CSharpSignInManager>()
                    .AddEntityFrameworkStores<CSharpUserDbContext>()
                    .AddDefaultTokenProviders();

            services.AddIdentityServer(options => 
            {
                options.UserInteraction.LoginUrl = "/idsr4/account/login";
                options.UserInteraction.LogoutUrl = "/idsr4/account/logout";
                options.UserInteraction.ConsentUrl = "/idsr4/consent/index";
            })
            .AddAspNetIdentity<IdentityUser>()
            .AddClientStore<ClientService>()
            .AddDeveloperSigningCredential()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            });

            return services;
        }

    }
}
