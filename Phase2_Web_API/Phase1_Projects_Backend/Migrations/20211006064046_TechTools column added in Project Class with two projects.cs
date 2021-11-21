using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase1_Projects_Backend.Migrations
{
    public partial class TechToolscolumnaddedinProjectClasswithtwoprojects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools" },
                values: new object[] { 9, "Email9", "Description9", "Domain9", "Title9", "Technologies and Tools 9" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools" },
                values: new object[] { 10, "Email10", "Description10", "Domain10", "Title10", "Technologies and Tools 10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools" },
                values: new object[] { 1, "Email1", "Description1", "Domain1", "Title1", null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools" },
                values: new object[] { 2, "Email2", "Description2", "Domain2", "Title2", null });
        }
    }
}
