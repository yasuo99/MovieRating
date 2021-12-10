using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePage.DataAccess.Migrations
{
    public partial class AddPGModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Movies",
                newName: "PGId");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestrictAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PGs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PGId",
                table: "Movies",
                column: "PGId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_PGs_PGId",
                table: "Movies",
                column: "PGId",
                principalTable: "PGs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_PGs_PGId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "PGs");

            migrationBuilder.DropIndex(
                name: "IX_Movies_PGId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "PGId",
                table: "Movies",
                newName: "Length");
        }
    }
}
