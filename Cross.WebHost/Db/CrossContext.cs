using Cross.WebHost.Entities;
using Microsoft.Data.Entity;

namespace Cross.WebHost.Db
{
    public class CrossContext : DbContext
    {
        public DbSet<User> ApplicationUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<RoleClaim> RoleClaims { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().HasKey(x => new {x.UserId, x.RoleId});

            modelBuilder.Entity<User>().HasIndex(c => c.UserName).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
