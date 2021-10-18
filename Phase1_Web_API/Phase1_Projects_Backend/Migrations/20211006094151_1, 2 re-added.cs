using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase1_Projects_Backend.Migrations
{
    public partial class _12readded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools" },
                values: new object[] { 1, "Email1", "Description1", "Domain1", "Title1", "Technologies and Tools 1" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle" },
                values: new object[] { 2, "Email2", "Description2", "Domain2", "Title2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);
        }
    }
}
