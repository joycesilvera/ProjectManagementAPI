using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementAPI.Migrations
{
    public partial class projectsToAzureDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    DateOfStart = table.Column<DateTime>(nullable: false),
                    TeamSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
