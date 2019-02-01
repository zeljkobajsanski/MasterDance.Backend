using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Persistence.Migrations
{
    public partial class Members : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dance",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gymnastics",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrainingTypes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingTypes");

            migrationBuilder.DropColumn(
                name: "Dance",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Gymnastics",
                table: "Persons");
        }
    }
}
