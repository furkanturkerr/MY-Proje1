using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abauts",
                columns: table => new
                {
                    AbautId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbautDetails1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AbautDetails2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    AbautImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AbautImage2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abauts", x => x.AbautId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subjeck = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WriterSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WriterImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WriterEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WriterPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterId);
                });

            migrationBuilder.CreateTable(
                name: "Headings",
                columns: table => new
                {
                    HeadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeadingName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HeadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    WriterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headings", x => x.HeadingId);
                    table.ForeignKey(
                        name: "FK_Headings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Headings_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentVlue = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ContentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeadingId = table.Column<int>(type: "int", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_Headings_HeadingId",
                        column: x => x.HeadingId,
                        principalTable: "Headings",
                        principalColumn: "HeadingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "WriterId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_HeadingId",
                table: "Contents",
                column: "HeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_WriterId",
                table: "Contents",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Headings_CategoryId",
                table: "Headings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Headings_WriterId",
                table: "Headings",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abauts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Headings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
