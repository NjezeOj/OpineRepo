using Microsoft.EntityFrameworkCore.Migrations;

namespace Opine.Server.Migrations
{
    public partial class AdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO AspNetRoles (Id, [Name], NormalizedName)
VALUES('ceb2f53f-7f4e-44d6-be75-042ee7857759', 'Admin', 'Admin')
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
