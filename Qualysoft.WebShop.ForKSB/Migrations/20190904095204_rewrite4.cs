using Microsoft.EntityFrameworkCore.Migrations;

namespace Qualysoft.WebShop.ForKSB.Migrations
{
    public partial class rewrite4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Accounts");
        }
    }
}
