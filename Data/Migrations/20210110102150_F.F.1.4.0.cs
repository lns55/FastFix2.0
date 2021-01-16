using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF140 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "carRepairUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carRepairUsers_UserId",
                table: "carRepairUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_carRepairUsers_AspNetUsers_UserId",
                table: "carRepairUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carRepairUsers_AspNetUsers_UserId",
                table: "carRepairUsers");

            migrationBuilder.DropIndex(
                name: "IX_carRepairUsers_UserId",
                table: "carRepairUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "carRepairUsers");

        }
    }
}
