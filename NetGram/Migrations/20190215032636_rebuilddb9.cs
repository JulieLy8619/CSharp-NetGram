using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetGram.Migrations
{
    public partial class rebuilddb9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostsTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTable", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "PostsTable",
                columns: new[] { "ID", "Author", "Description", "ImageURL", "Title" },
                values: new object[,]
                {
                    { 1, "Bob Smith", "a really cool description", "tempImage.jpg", "Creative Title 1" },
                    { 2, "Sally Smith", "a not cool description", "tempImage2.jpg", "Creative Title 2" },
                    { 3, "John Smith", "a lame description", "tempImage3.jpg", "Creative Title 3" },
                    { 4, "Jane Smith", "just a description", "tempImage4.jpg", "Creative Title 4" },
                    { 5, "Billy Smith", "a secret description that if I tell you I have to k*** you ;)", "tempImage5.jpg", "Creative Title 5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsTable");
        }
    }
}
