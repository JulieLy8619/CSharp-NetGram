using Microsoft.EntityFrameworkCore.Migrations;

namespace NetGram.Migrations
{
    public partial class _021619rebuild1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "~/butterfly.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "~/gummybears.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "~/leaf.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "~/station.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "~/fairy.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "tempImage.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "tempImage2.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "tempImage3.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "tempImage4.jpg");

            migrationBuilder.UpdateData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "tempImage5.jpg");
        }
    }
}
