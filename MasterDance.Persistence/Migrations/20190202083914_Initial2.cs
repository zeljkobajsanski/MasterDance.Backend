using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Persistence.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prize_Competitions_CompetitionId",
                table: "Prize");

            migrationBuilder.DropForeignKey(
                name: "FK_Prize_Persons_MemberId",
                table: "Prize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prize",
                table: "Prize");

            migrationBuilder.RenameTable(
                name: "Prize",
                newName: "Prizes");

            migrationBuilder.RenameIndex(
                name: "IX_Prize_MemberId",
                table: "Prizes",
                newName: "IX_Prizes_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Prize_CompetitionId",
                table: "Prizes",
                newName: "IX_Prizes_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prizes",
                table: "Prizes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Competitions_CompetitionId",
                table: "Prizes",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prizes_Persons_MemberId",
                table: "Prizes",
                column: "MemberId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Competitions_CompetitionId",
                table: "Prizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Prizes_Persons_MemberId",
                table: "Prizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prizes",
                table: "Prizes");

            migrationBuilder.RenameTable(
                name: "Prizes",
                newName: "Prize");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_MemberId",
                table: "Prize",
                newName: "IX_Prize_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Prizes_CompetitionId",
                table: "Prize",
                newName: "IX_Prize_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prize",
                table: "Prize",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prize_Competitions_CompetitionId",
                table: "Prize",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prize_Persons_MemberId",
                table: "Prize",
                column: "MemberId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
