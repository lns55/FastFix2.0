using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF160 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_carRepairUsers",
                table: "carRepairUsers");

            migrationBuilder.RenameTable(
                name: "carRepairUsers",
                newName: "CarRepairUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RepairFrom",
                table: "NewApplications",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRepairUsers",
                table: "CarRepairUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnswersForApps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueTitle = table.Column<string>(nullable: true),
                    Car = table.Column<string>(nullable: true),
                    RepairFrom = table.Column<string>(nullable: true),
                    RepairTill = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    TypeOfWork = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersForApps", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "AnswersForApps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRepairUsers",
                table: "CarRepairUsers");

            migrationBuilder.RenameTable(
                name: "CarRepairUsers",
                newName: "carRepairUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RepairFrom",
                table: "NewApplications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_carRepairUsers",
                table: "carRepairUsers",
                column: "Id");
        }
    }
}
