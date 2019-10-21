using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CSharp.MvcClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = Configuration["Idsr4:IssuerUri"];

                options.RequireHttpsMetadata = false;

                options.ClientId = Configuration["Idsr4:ClientId"];

                options.SaveTokens = true;

                options.Events = new OpenIdConnectEvents
                {
                    OnTokenResponseReceived = async (context) =>
                    {
                        var aa = context;
                    },
                    OnRemoteSignOut = async (context) =>
                    {
                        var aa = context;
                    },
                    OnSignedOutCallbackRedirect = async (context) =>
                    {
                        var aa = context;
                    },
                    OnRedirectToIdentityProviderForSignOut = async (context) =>
                    {
                        var aa = context;
                    },
                    OnRedirectToIdentityProvider = async (context) =>
                    {
                        var aa = context;
                    },
                    OnMessageReceived = async (context) =>
                    {
                        var aa = context;
                    },
                    OnAuthorizationCodeReceived = async (context) =>
                    {
                        var aa = context;
                    },
                    OnAuthenticationFailed = async (context) =>
                    {
                        var aa = context;
                    },
                    OnTokenValidated = async (context) =>
                    {
                        var aa = context;
                    },
                    OnUserInformationReceived = async (context) =>
                    {
                        var aa = context;
                    },
                };
            });

            services.AddControllers();

            services.AddRazorPages();

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
