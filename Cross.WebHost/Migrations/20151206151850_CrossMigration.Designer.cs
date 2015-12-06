using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Cross.WebHost.Db;

namespace Cross.WebHost.Migrations
{
    [DbContext(typeof(CrossContext))]
    [Migration("20151206151850_CrossMigration")]
    partial class CrossMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cross.WebHost.Entities.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumName")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Updated");

                    b.HasKey("AlbumId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumAlbumId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("PictureUrl")
                        .IsRequired();

                    b.HasKey("PictureId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTime?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 255);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();
                });

            modelBuilder.Entity("Cross.WebHost.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.UserInRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.Album", b =>
                {
                    b.HasOne("Cross.WebHost.Entities.User")
                        .WithMany()
                        .HasForeignKey("CreateUserId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.Picture", b =>
                {
                    b.HasOne("Cross.WebHost.Entities.Album")
                        .WithMany()
                        .HasForeignKey("AlbumAlbumId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.RoleClaim", b =>
                {
                    b.HasOne("Cross.WebHost.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.UserClaim", b =>
                {
                    b.HasOne("Cross.WebHost.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Cross.WebHost.Entities.UserInRole", b =>
                {
                    b.HasOne("Cross.WebHost.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Cross.WebHost.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
