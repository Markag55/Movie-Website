using Microsoft.EntityFrameworkCore.Migrations;

namespace CapProj_Updated_.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    tconst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAdult = table.Column<float>(type: "real", nullable: true),
                    startYear = table.Column<float>(type: "real", nullable: true),
                    endYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    runtimeMinutes = table.Column<float>(type: "real", nullable: true),
                    genres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
