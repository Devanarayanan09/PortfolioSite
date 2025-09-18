using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Company = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsCurrent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Technologies = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ProjectUrl = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Technologies = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExperienceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Company", "Description", "EndDate", "IsCurrent", "Position", "StartDate", "Technologies" },
                values: new object[] { 1, "Infosys Limited", "In charge of designing, developing, maintaining, and deploying scalable web applications using ASP.NET MVC, with active involvement in release management to test and production environments.", new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Senior Systems Engineer", new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#, ASP.NET MVC, SQL Server, .NET Core, ADO.NET" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ExperienceId", "ImageUrl", "IsFeatured", "ProjectUrl", "Technologies", "Title" },
                values: new object[,]
                {
                    { 1, "• Developed 5+ declarations requiring employee acceptance in line with client specifications, enabling document generation and download functionality of the declarations for admin review. <br>• Configured visa-types by refactoring 20+ stored procedures and application logic. <br>• Implemented automated mailers for status updates, eliminating manual processing entirely. ", 1, "/images/Projects/GLOMO.png", true, "", "ASP.NET Core, ASP.NET, MVC, SQL Server, Entity Framework", "GLOMO" },
                    { 2, "• Designed various admin functionalities like document download, approval/rejection, admin stages etc. <br>• Integrated file validation APIs to enforce country-specific document compliance, reducing manual verification by 90%. <br>• Deployed an email notification system that removed all manual status update tasks. ", 1, "/images/Projects/IVISA.png", true, "", "ASP.NET, ADO.NET, MVC, SQL Server", "IVISA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ExperienceId",
                table: "Projects",
                column: "ExperienceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Experiences");
        }
    }
}
