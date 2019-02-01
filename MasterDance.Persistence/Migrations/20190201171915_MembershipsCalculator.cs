using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Persistence.Migrations
{
    public partial class MembershipsCalculator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipAmount",
                table: "Settings");

            migrationBuilder.AddColumn<string>(
                name: "MembershipCalculator",
                table: "Settings",
                maxLength: 512,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipCalculator",
                table: "Settings");

            migrationBuilder.AddColumn<decimal>(
                name: "MembershipAmount",
                table: "Settings",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
