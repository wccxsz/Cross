using Cross.WebHost.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Cross.WebHost.Dbcontext
{
    public class CrossContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }
    }
}
