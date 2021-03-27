using Microsoft.EntityFrameworkCore.Migrations;

namespace Opine.Server.Migrations
{
    public partial class CustomUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomUserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomUserName",
                table: "AspNetUsers");
        }
    }
}
