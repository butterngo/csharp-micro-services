namespace CSharp.OAuth.Server.Extensions
{
    using CSharp.OAuth.Server.Idsr4.Services;
    using CSharp.OAuth.Server.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IIdsr4Service, Idsr4Service>();

            return services;
        }
    }
}
