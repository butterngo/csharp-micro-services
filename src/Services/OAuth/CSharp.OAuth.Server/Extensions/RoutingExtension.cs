namespace CSharp.OAuth.Server.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    public static class RoutingExtension
    {
        public static IApplicationBuilder UseRouting(this IApplicationBuilder app, IConfiguration configuration) 
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "areas", "areas",
                   pattern: "{area:exists}/{controller=Account}/{action=SignIn}/{id?}");
            });

            //app.UseSpa(spa => { spa.Options.SourcePath = "ClientApp"; });

            return app;
        }
    }
}
