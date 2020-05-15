using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpLocally.Infrastructure.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("492248ed-cc74-4b8a-b3c4-02844dd5c0fc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b3be6e69-f441-4b4d-9c82-3e00debc7adc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f3985741-d2a3-40aa-af4e-71e4660e4d66"));

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("feec1bbe-e310-4136-8b3a-a5613a1d51c2"), "Admin" },
                    { new Guid("9d27ea85-ffdb-4dcd-8232-11c8a48decb7"), "Company" },
                    { new Guid("6eb59577-d41f-4bdd-a073-badcee263b73"), "Customer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6eb59577-d41f-4bdd-a073-badcee263b73"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9d27ea85-ffdb-4dcd-8232-11c8a48decb7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("feec1bbe-e310-4136-8b3a-a5613a1d51c2"));

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("492248ed-cc74-4b8a-b3c4-02844dd5c0fc"), "Admin" },
                    { new Guid("b3be6e69-f441-4b4d-9c82-3e00debc7adc"), "Company" },
                    { new Guid("f3985741-d2a3-40aa-af4e-71e4660e4d66"), "Customer" }
                });
        }
    }
}
