using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVprogram.Entity.Migrations
{
    public partial class InitialCreater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IDUsersChannelList",
                table: "userChannelLists");

            migrationBuilder.DropColumn(
                name: "IDprogram",
                table: "programs");

            migrationBuilder.DropColumn(
                name: "IDChannel",
                table: "channels");

            migrationBuilder.DropColumn(
                name: "IDAdmin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admin",
                table: "admin",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_admin",
                table: "admin");

            migrationBuilder.RenameTable(
                name: "admin",
                newName: "Admin");

            migrationBuilder.AddColumn<Guid>(
                name: "IDUser",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDUsersChannelList",
                table: "userChannelLists",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDprogram",
                table: "programs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDChannel",
                table: "channels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IDAdmin",
                table: "Admin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");
        }
    }
}
