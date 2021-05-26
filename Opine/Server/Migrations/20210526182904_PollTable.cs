using Microsoft.EntityFrameworkCore.Migrations;

namespace Opine.Server.Migrations
{
    public partial class PollTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "B",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "C",
                table: "Polls");

            migrationBuilder.RenameColumn(
                name: "D",
                table: "Polls",
                newName: "Count");

            migrationBuilder.AddColumn<string>(
                name: "Option",
                table: "Polls",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Option",
                table: "Polls");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Polls",
                newName: "D");

            migrationBuilder.AddColumn<int>(
                name: "A",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "B",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "C",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
