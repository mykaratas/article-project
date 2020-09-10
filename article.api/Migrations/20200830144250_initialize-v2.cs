using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace article.api.Migrations
{
    public partial class initializev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ArticleCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ArticleCategories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("2b6880a4-909c-4c66-b091-56a8235d6303"), "Article Content 1", new DateTime(2020, 8, 30, 17, 42, 49, 623, DateTimeKind.Local).AddTicks(8080), "Full Name 1", "Article Title 1" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("b8c2d73a-be05-427c-ac59-fb6867e2d678"), "Article Content 2", new DateTime(2020, 8, 30, 17, 42, 49, 630, DateTimeKind.Local).AddTicks(5780), "Full Name 2", "Article Title 2" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreatedDate", "FullName", "Title" },
                values: new object[] { new Guid("9ee2dac8-4f31-4a41-b88b-3b708ec458d5"), "Article Content 3", new DateTime(2020, 8, 30, 17, 42, 49, 630, DateTimeKind.Local).AddTicks(5840), "Full Name 3", "Article Title 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2b6880a4-909c-4c66-b091-56a8235d6303"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9ee2dac8-4f31-4a41-b88b-3b708ec458d5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b8c2d73a-be05-427c-ac59-fb6867e2d678"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ArticleCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ArticleCategories");

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
        }
    }
}
