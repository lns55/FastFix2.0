using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF172 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ApplicationsInProgress",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ApplicationsInProgress",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ApplicationsInProgress");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ApplicationsInProgress");
        }
    }
}
