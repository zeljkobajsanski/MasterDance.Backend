using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterDance.Web.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    Contact_Address = table.Column<string>(maxLength: 255, nullable: true),
                    Contact_Email = table.Column<string>(maxLength: 255, nullable: true),
                    Contact_Phone = table.Column<string>(maxLength: 255, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    MemberType = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    JoinedDate = table.Column<DateTime>(nullable: true),
                    FatherId = table.Column<int>(nullable: true),
                    MotherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_FatherId",
                        column: x => x.FatherId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_MotherId",
                        column: x => x.MotherId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    Content_FileName = table.Column<string>(maxLength: 255, nullable: true),
                    Content_ContentType = table.Column<string>(maxLength: 32, nullable: true),
                    Content_Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Persons_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Persons_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_MemberId",
                table: "Documents",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_MemberId",
                table: "Image",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FatherId",
                table: "Persons",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MotherId",
                table: "Persons",
                column: "MotherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
