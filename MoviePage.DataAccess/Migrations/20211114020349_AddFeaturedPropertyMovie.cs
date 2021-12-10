using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePage.DataAccess.Migrations
{
    public partial class AddFeaturedPropertyMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Movies");
        }
    }
}
