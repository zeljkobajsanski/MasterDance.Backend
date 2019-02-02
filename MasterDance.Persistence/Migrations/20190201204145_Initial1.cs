using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Persistence.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Memberships",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Memberships",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Memberships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Memberships",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Memberships");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Memberships");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Memberships",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
