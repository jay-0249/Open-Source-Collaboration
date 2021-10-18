using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase1_Projects_Backend.Migrations
{
    public partial class userDbSetcreatedwithprojectmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 11);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserList",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    githubProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gitlabProfile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserList", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "TechTools",
                value: "To be Updated");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools", "UserId" },
                values: new object[] { 21, "Email11", "Description11", "Domain11", "Title11", "To be Updated", null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools", "UserId" },
                values: new object[] { 20, "Email10", "Description10", "Domain10", "Title10", "Technologies and Tools 10", null });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_UserList_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "UserList",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_UserList_UserId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "UserList");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "TechTools",
                value: null);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle" },
                values: new object[] { 11, "Email11", "Description11", "Domain11", "Title11" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ContactMail", "Description", "Domain", "ProjectTitle", "TechTools" },
                values: new object[] { 10, "Email10", "Description10", "Domain10", "Title10", "Technologies and Tools 10" });
        }
    }
}
