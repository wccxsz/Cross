using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Cross.DbFactory.Migrations
{
    public partial class Cross : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<int>_IdentityRole<int>_RoleId", table: "RoleClaim");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<int>_IdentityUser<int>_UserId", table: "UserClaim");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<int>_IdentityUser<int>_UserId", table: "UserLogin");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<int>_IdentityRole<int>_RoleId", table: "UserInRole");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<int>_IdentityUser<int>_UserId", table: "UserInRole");
            migrationBuilder.CreateTable(
                name: "TaskSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    CreateUserId = table.Column<int>(nullable: true),
                    ImageTaskCount = table.Column<int>(nullable: false),
                    LastEditTime = table.Column<DateTime>(nullable: false),
                    StoryTaskCount = table.Column<int>(nullable: false),
                    VideoTaskCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskSet_IdentityUser<int>_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "Task",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedTime",
                table: "Task",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddForeignKey(
                name: "FK_Task_IdentityUser<int>_CreateUserId",
                table: "Task",
                column: "CreateUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<int>_IdentityRole<int>_RoleId",
                table: "RoleClaim",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<int>_IdentityUser<int>_UserId",
                table: "UserClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<int>_IdentityUser<int>_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_IdentityRole<int>_RoleId",
                table: "UserInRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_IdentityUser<int>_UserId",
                table: "UserInRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Task_IdentityUser<int>_CreateUserId", table: "Task");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<int>_IdentityRole<int>_RoleId", table: "RoleClaim");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<int>_IdentityUser<int>_UserId", table: "UserClaim");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<int>_IdentityUser<int>_UserId", table: "UserLogin");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<int>_IdentityRole<int>_RoleId", table: "UserInRole");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<int>_IdentityUser<int>_UserId", table: "UserInRole");
            migrationBuilder.DropColumn(name: "CreateUserId", table: "Task");
            migrationBuilder.DropColumn(name: "FinishedTime", table: "Task");
            migrationBuilder.DropTable("TaskSet");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<int>_IdentityRole<int>_RoleId",
                table: "RoleClaim",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<int>_IdentityUser<int>_UserId",
                table: "UserClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<int>_IdentityUser<int>_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_IdentityRole<int>_RoleId",
                table: "UserInRole",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<int>_IdentityUser<int>_UserId",
                table: "UserInRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
