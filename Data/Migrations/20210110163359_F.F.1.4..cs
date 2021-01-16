using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "carRepairUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_carRepairUserId",
                table: "AspNetUsers",
                column: "carRepairUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_carRepairUsers_carRepairUserId",
                table: "AspNetUsers",
                column: "carRepairUserId",
                principalTable: "carRepairUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_carRepairUsers_carRepairUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_carRepairUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "carRepairUserId",
                table: "AspNetUsers");
        }
    }
}
