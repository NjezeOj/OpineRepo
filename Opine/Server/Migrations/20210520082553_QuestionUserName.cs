using Microsoft.EntityFrameworkCore.Migrations;

namespace Opine.Server.Migrations
{
    public partial class QuestionUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionUserName",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionUserName",
                table: "Questions");
        }
    }
}
