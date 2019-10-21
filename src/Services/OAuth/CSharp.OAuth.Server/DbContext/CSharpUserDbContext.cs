namespace CSharp.OAuth.Server.DbContext
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CSharpUserDbContext : IdentityDbContext
    {
        public CSharpUserDbContext(DbContextOptions<CSharpUserDbContext> options) : base(options) { }
    }
}
