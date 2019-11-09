namespace CSharp.OAuth.Server
{
    using CSharp.OAuth.Server.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

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
            services.AddCors();

            services.AddControllersWithViews();

            services.AddSingleton(Configuration);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddIdsr4(Configuration);

            services.AddHttpClient(Configuration);

            services.AddServices(Configuration);

            services.AddTransient<CSharpOAuthServerMigration>();
            //services.AddSwashbuckle(Configuration);
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CSharpOAuthServerMigration migration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            migration.InitData();

            //app.UseSwashbuckle(Configuration);

            app.UseStaticFiles();
           
            //app.UseSpaStaticFiles();

            app.UseAuthorization();

            app.UseIdentityServer();

            app.UseCors(Configuration);

            app.UseRouting(Configuration);

        }
    }
}
