using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePage.DataAccess.Migrations
{
    public partial class AddShortNamePropertyMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Movies");
        }
    }
}
