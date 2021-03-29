using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFix2._0.Data.Migrations
{
    public partial class FF160 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "AnswersForApps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<string>(nullable: true),
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
        }
    }
}
