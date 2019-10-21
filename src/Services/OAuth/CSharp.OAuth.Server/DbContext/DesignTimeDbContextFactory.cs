namespace CSharp.OAuth.Server.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class CSharpUserDbContextDesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<CSharpUserDbContext>
    {
        /// <summary>
        /// Use "development mode" to generate script migration.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public CSharpUserDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
               .Build();

            var builder = new DbContextOptionsBuilder<CSharpUserDbContext>();

            var connectionString = configuration.GetConnectionString("CSharpOAuthServerConnectionString");

            builder.UseSqlServer(connectionString);

            return new CSharpUserDbContext(builder.Options);
        }
    }

}
