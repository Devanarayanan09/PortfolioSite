using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class LandingPageExperienceSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Engineered dual-platform solutions (Admin & Employee Portals) for Infosys, streamlining the end-to-end lifecycle of onsite employees. Developed critical systems for document verification, visa processing, and manager approval workflows, ensuring seamless international transitions and landing verification for global talent.");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Spearheading backend development for Cocopalms, a leading Kuwaiti health-tech ecosystem specializing in diet-based food delivery. Developed and maintained several modules of 'Bizo Suite,' a comprehensive accounting engine integrated with their food delivery infrastructure to manage complex financial operations across multiple web and mobile platforms.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "In charge of designing, developing, maintaining, and deploying scalable web applications using ASP.NET MVC, with active involvement in release management to test and production environments.");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Architecting robust backend systems and RESTful APIs. Specializing in high-performance data processing and scalable architectures using .NET Core and PostgreSQL.");
        }
    }
}
