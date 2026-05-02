using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectDataDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Company", "Description", "EndDate", "IsCurrent", "Position", "StartDate", "Technologies" },
                values: new object[] { 2, "Cocopalms Tech Pvt Lmtd", "Architecting robust backend systems and RESTful APIs. Specializing in high-performance data processing and scalable architectures using .NET Core and PostgreSQL.", null, true, "Senior Backend Developer", new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASP.NET Core Web API, PostgreSQL, Microservices" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/Projects/GLOMO.jpg");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/Projects/GLOMO.jpg");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ExperienceId", "ImageUrl", "IsFeatured", "ProjectUrl", "Technologies", "Title" },
                values: new object[] { 3, "• Developed backend services using .NET Web API with PostgreSQL for scalable and efficient data management <br>• Led development of finance modules, implementing core accounting logic and system workflows <br>• Implemented GST compliance features for Indian operations, ensuring accurate taxation and reporting <br>• Designed and built 15+ accounting and financial reports, improving data visibility and reporting efficiency <br>• Developed statistical reporting features to support business analytics and decision-making <br>• Implemented multi-branch architecture, enabling seamless operations across multiple business units <br>• Built 18+ kitchen management reports covering diet planning, inventory tracking, and operational insights <br>• Performed API testing and validation using Postman and Swagger, ensuring reliability and correctness <br>• Wrote unit tests (AI-assisted) to improve code quality and maintainability <br>• Leveraged AI tools such as Antigravity to enhance development productivity and accelerate implementation <br>• Collaborated on improving system performance, data accuracy, and scalability", 2, "/images/Projects/Cocopalms.png", true, "https://bizosuite.com/", "ASP.NET Core Web API, PostgreSQL, Swagger", "Bizo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/Projects/GLOMO.png");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/Projects/IVISA.png");
        }
    }
}
