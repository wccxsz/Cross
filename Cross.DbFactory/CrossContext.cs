using Cross.Entities;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Cross.DbFactory
{
    public class CrossContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>

    {
        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskSet> TaskSets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=GrowDb;User Id=postgres;Password=whldym;Timeout=15;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //放到base之前没有作用,自定义表名称
            builder.Entity<IdentityUser<int>>().ToTable("User").HasIndex("UserName");
            builder.Entity<IdentityRole<int>>().ToTable("Role").HasIndex("Name");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserInRole");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
        }
    }
}
