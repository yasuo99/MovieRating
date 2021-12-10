using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePage.DataAccess.Migrations
{
    public partial class UpdateMPAAPGModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MPAA",
                table: "PGs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MPAA",
                table: "PGs");
        }
    }
}
