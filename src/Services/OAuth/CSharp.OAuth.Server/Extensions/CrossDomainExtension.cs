namespace CSharp.OAuth.Server.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    public static class CrossDomainExtension
    {
        public static IApplicationBuilder UseCors(this IApplicationBuilder app,
            IConfiguration configuration) 
        {
            app.UseCors(configurePolicy => 
            {
                configurePolicy
                .WithOrigins(GetOrigins())
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });

            return app;
        }

        public static string[] GetOrigins() 
        {
            return new[] { "http://localhost:4200" };
        }
    }
}
