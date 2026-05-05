using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDataTechTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Technologies",
                value: "Next.js, TypeScript, Tailwind CSS, Framer Motion, .NET Core Web API, PostgreSQL");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Technologies",
                value: "Next.js 14, ASP.NET Core, PostgreSQL, TypeScript, Cloud Asset Management (S3), SEO/Metadata API, RESTful API Design");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Technologies",
                value: "Next.js, TypeScript, Supabase, Tailwind CSS, Framer Motion");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                column: "Technologies",
                value: "Next.js 14, ASP.NET Core, PostgreSQL (Supabase), TypeScript, Cloud Asset Management (S3), SEO/Metadata API, RESTful API Design");
        }
    }
}
