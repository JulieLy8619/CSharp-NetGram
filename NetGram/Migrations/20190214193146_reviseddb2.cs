using Microsoft.EntityFrameworkCore.Migrations;

namespace NetGram.Migrations
{
    public partial class reviseddb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 1,
                column: "Title",
                value: "Creative Title 1");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 2,
                column: "Title",
                value: "Creative Title 2");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 3,
                column: "Title",
                value: "Creative Title 3");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 4,
                column: "Title",
                value: "Creative Title 4");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 5,
                column: "Title",
                value: "Creative Title 5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 1,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 2,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 3,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 4,
                column: "Title",
                value: null);

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 5,
                column: "Title",
                value: null);
        }
    }
}
