using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Web.Data.Migrations
{
    public partial class MemberGroupsAndCoaches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberGroupId",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MemberGroupId",
                table: "Persons",
                column: "MemberGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_MemberGroups_MemberGroupId",
                table: "Persons",
                column: "MemberGroupId",
                principalTable: "MemberGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_MemberGroups_MemberGroupId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "MemberGroups");

            migrationBuilder.DropIndex(
                name: "IX_Persons_MemberGroupId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MemberGroupId",
                table: "Persons");
        }
    }
}
