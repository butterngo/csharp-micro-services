namespace CSharp.Core.CSharpSwagger.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Collections.Generic;
    using System.Linq;

    public static class SwashbuckleExtension
    {
        public static IServiceCollection AddSwashbuckle(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AddFileUploadParams>();

                c.SwaggerDoc(
                    "v1",
                    new Info
                    {
                        Title = "Services",
                        Description = "Web API",
                        Version = "v1"
                    }
                 );

                c.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter JWT with Bearer into field",
                        Name = "Authorization",
                        Type = "apiKey"
                    });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });

                //var filePath = $"{AppDomain.CurrentDomain.BaseDirectory}//StaticFiles//SwaggerDoc.xml";

                //if (File.Exists(filePath))
                //{
                //    c.IncludeXmlComments(filePath);
                //}

            });

            return services;
        }

        public static IApplicationBuilder UseSwashbuckle(this IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Document API V1");
            });

            return app;
        }
    }

    public class AddFileUploadParams : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                return;

            var formFileParams = context.ApiDescription.ActionDescriptor.Parameters
                                    .Where(x => x.ParameterType.IsAssignableFrom(typeof(IFormFile)))
                                    .Select(x => x.Name)
                                    .ToList();

            var formFileSubParams = context.ApiDescription.ActionDescriptor.Parameters
                .SelectMany(x => x.ParameterType.GetProperties())
                .Where(x => x.PropertyType.IsAssignableFrom(typeof(IFormFile)))
                .Select(x => x.Name)
                .ToList();

            var allFileParamNames = formFileParams.Union(formFileSubParams);

            if (!allFileParamNames.Any())
                return;

            var paramsToRemove = new List<IParameter>();

            foreach (var param in operation.Parameters)
            {
                if (allFileParamNames.Any(x => x.Equals(param.Name)))
                {
                    paramsToRemove.Add(param);
                }
            }

            paramsToRemove.ForEach(x => operation.Parameters.Remove(x));

            foreach (var paramName in allFileParamNames)
            {
                var fileParam = new NonBodyParameter
                {
                    Type = "file",
                    Name = paramName,
                    In = "formData",
                };
                operation.Parameters.Add(fileParam);
            }

            foreach (IParameter param in operation.Parameters)
            {
                param.In = "formData";
            }

            operation.Consumes = new List<string>() { "multipart/form-data" };
        }
    }
}
