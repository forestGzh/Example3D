using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Example3D.Account.Infrastructure.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: true),
                    Address_Street = table.Column<string>(maxLength: 10, nullable: true),
                    Address_City = table.Column<string>(maxLength: 10, nullable: true),
                    Address_Country = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
