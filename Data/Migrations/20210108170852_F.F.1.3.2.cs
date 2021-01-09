using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewApplications_AspNetUsers_UserId",
                table: "NewApplications");

            migrationBuilder.DropIndex(
                name: "IX_NewApplications_UserId",
                table: "NewApplications");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "NewApplications",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "NewApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewApplications_UserId1",
                table: "NewApplications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_NewApplications_AspNetUsers_UserId1",
                table: "NewApplications",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewApplications_AspNetUsers_UserId1",
                table: "NewApplications");

            migrationBuilder.DropIndex(
                name: "IX_NewApplications_UserId1",
                table: "NewApplications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "NewApplications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "NewApplications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_NewApplications_UserId",
                table: "NewApplications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewApplications_AspNetUsers_UserId",
                table: "NewApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
