using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace article.api.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
