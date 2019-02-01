using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Persistence.Migrations
{
    public partial class MembershipsCalculator1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipCalculator",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Settings",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Settings",
                maxLength: 512,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "MembershipCalculator",
                table: "Settings",
                maxLength: 512,
                nullable: true);
        }
    }
}
