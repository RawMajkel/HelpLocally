using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpLocally.Infrastructure.Migrations
{
    public partial class OneRoleOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

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

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f3dc1535-5996-4e62-b9e0-c77835630739"), "Admin" },
                    { new Guid("fb555b1d-d7a5-4849-aa60-8bbf8a555cdb"), "Company" },
                    { new Guid("0778e789-2445-43b1-a6c9-6f9fcac62961"), "Customer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0778e789-2445-43b1-a6c9-6f9fcac62961"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f3dc1535-5996-4e62-b9e0-c77835630739"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb555b1d-d7a5-4849-aa60-8bbf8a555cdb"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("feec1bbe-e310-4136-8b3a-a5613a1d51c2"), "Admin" },
                    { new Guid("9d27ea85-ffdb-4dcd-8232-11c8a48decb7"), "Company" },
                    { new Guid("6eb59577-d41f-4bdd-a073-badcee263b73"), "Customer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }
    }
}
