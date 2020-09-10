using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace article.api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Categories_CategoryId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CategoryId1",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("55da32c4-68b3-4a45-a4cc-ccdbeb6d3996"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b7eed6ee-9cc2-445b-983c-277c8a540d2f"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c0727ed5-5785-4a3b-9b4e-6b0698720369"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
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
                values: new object[] { new Guid("c922cf2f-290f-4239-b6f5-d1ba1b4619e5"), "Article Content 1", new DateTime(2020, 9, 1, 1, 13, 27, 485, DateTimeKind.Local).AddTicks(7430), "Full Name 1", "Article Title 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("2f229045-c7e8-4a4a-a738-ee0ec910e292"), "Article Content 2", new DateTime(2020, 9, 1, 1, 13, 27, 493, DateTimeKind.Local).AddTicks(4830), "Full Name 2", "Article Title 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("fdaa0128-0edc-46ab-951c-d5feab0635d9"), "Article Content 3", new DateTime(2020, 9, 1, 1, 13, 27, 493, DateTimeKind.Local).AddTicks(4910), "Full Name 3", "Article Title 3" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2f229045-c7e8-4a4a-a738-ee0ec910e292"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c922cf2f-290f-4239-b6f5-d1ba1b4619e5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("fdaa0128-0edc-46ab-951c-d5feab0635d9"));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("c0727ed5-5785-4a3b-9b4e-6b0698720369"), null, null, "Article Content 1", new DateTime(2020, 8, 31, 1, 24, 59, 107, DateTimeKind.Local).AddTicks(4560), "Full Name 1", "Article Title 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("55da32c4-68b3-4a45-a4cc-ccdbeb6d3996"), null, null, "Article Content 2", new DateTime(2020, 8, 31, 1, 24, 59, 114, DateTimeKind.Local).AddTicks(3420), "Full Name 2", "Article Title 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("b7eed6ee-9cc2-445b-983c-277c8a540d2f"), null, null, "Article Content 3", new DateTime(2020, 8, 31, 1, 24, 59, 114, DateTimeKind.Local).AddTicks(3500), "Full Name 3", "Article Title 3" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId1",
                table: "Articles",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Categories_CategoryId1",
                table: "Articles",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
