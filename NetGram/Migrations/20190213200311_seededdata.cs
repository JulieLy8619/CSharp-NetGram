using Microsoft.EntityFrameworkCore.Migrations;

namespace NetGram.Migrations
{
    public partial class seededdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostsTable",
                columns: new[] { "ID", "Author", "Description", "ImageURL" },
                values: new object[,]
                {
                    { 1, "Bob Smith", "a really cool description", "tempImage.jpg" },
                    { 2, "Sally Smith", "a not cool description", "tempImage2.jpg" },
                    { 3, "John Smith", "a lame description", "tempImage3.jpg" },
                    { 4, "Jane Smith", "just a description", "tempImage4.jpg" },
                    { 5, "Billy Smith", "a secret description that if I tell you I have to k*** you ;)", "tempImage5.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PostsTable",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
