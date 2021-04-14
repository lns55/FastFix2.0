using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersCars",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CarModel = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    CarPlate = table.Column<string>(nullable: true),
                    VinCode = table.Column<string>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersCars");
        }
    }
}
