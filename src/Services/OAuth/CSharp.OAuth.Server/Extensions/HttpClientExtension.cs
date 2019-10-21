namespace CSharp.OAuth.Server.Extensions
{
    using CSharp.OAuth.Server.Constants;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class HttpClientExtension
    {
        
        public static IServiceCollection AddHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(HttpClientContants.Idsr4,
                client => client.BaseAddress = new Uri(configuration.GetValue<string>(AppSettingContants.Idsr4.IssuerUri)));

            return services;
        }
    }

    
}
