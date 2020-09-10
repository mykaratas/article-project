using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace article.api.Migrations
{
    public partial class initializev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("71913a3f-496c-43c8-8437-0ec0f039ea41"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a501224f-f1c4-4524-a03b-2a0671b5094c"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("eef23d8b-bcbc-4def-aeb0-ed647f5b191b"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("037db917-1e68-4402-9c98-29e8bde359c6"), "Article Content 1", new DateTime(2020, 8, 30, 2, 53, 2, 635, DateTimeKind.Local).AddTicks(1700), "Full Name 1", "Article Title 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("ebcf9c04-2159-4d7b-96c1-e3ea374b0af3"), "Article Content 2", new DateTime(2020, 8, 30, 2, 53, 2, 641, DateTimeKind.Local).AddTicks(9540), "Full Name 2", "Article Title 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("e18c6d45-08ea-4376-869b-352df18be1bf"), "Article Content 3", new DateTime(2020, 8, 30, 2, 53, 2, 641, DateTimeKind.Local).AddTicks(9600), "Full Name 3", "Article Title 3" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("037db917-1e68-4402-9c98-29e8bde359c6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e18c6d45-08ea-4376-869b-352df18be1bf"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ebcf9c04-2159-4d7b-96c1-e3ea374b0af3"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("eef23d8b-bcbc-4def-aeb0-ed647f5b191b"), "Article Content 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Name 1", "Article Title 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("71913a3f-496c-43c8-8437-0ec0f039ea41"), "Article Content 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Name 2", "Article Title 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("a501224f-f1c4-4524-a03b-2a0671b5094c"), "Article Content 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full Name 3", "Article Title 3" });
        }
    }
}
