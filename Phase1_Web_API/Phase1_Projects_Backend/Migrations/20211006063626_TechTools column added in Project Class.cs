using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase1_Projects_Backend.Migrations
{
    public partial class TechToolscolumnaddedinProjectClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TechTools",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TechTools",
                table: "Projects");
        }
    }
}
