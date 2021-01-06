using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF131 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(nullable: true),
                    Car = table.Column<string>(nullable: true),
                    RepairFrom = table.Column<DateTime>(nullable: false),
                    RepairTill = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    TypeOfWork = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewApplications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewApplications_UserId",
                table: "NewApplications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewApplications");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
