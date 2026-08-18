using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "• Engineered scalable backend services using .NET Web API and PostgreSQL, implementing business logic, data processing, and reporting capabilities for enterprise applications <br>• Led development of finance modules, implementing core accounting logic and system workflows <br>• Designed and implemented 15+ accounting and financial reports covering financial analysis and accounting operations <br>• Designed and implemented 18+ kitchen management reports covering diet planning, inventory, production, subscriptions, delivery, shop orders, POS orders, and operational KPIs <br>• Developed statistical reporting features to support business analytics and data-driven decision-making <br>• Implemented multi-branch architecture, enabling seamless operations across multiple business units <br>• Worked with a multi-tenant database architecture using separate PostgreSQL databases per tenant, supporting database changes and deployments across multiple tenant environments <br>• Optimized complex SQL queries and PostgreSQL functions to improve reporting performance and reduce unnecessary database processing <br>• Performed API testing and validation using Postman and Swagger, ensuring reliability and correctness <br>• Wrote AI-assisted unit tests to improve code quality, maintainability, and test coverage <br>• Leveraged AI-assisted development and testing tools to accelerate implementation, troubleshoot complex issues, generate test coverage, and improve development productivity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "• Developed backend services using .NET Web API with PostgreSQL for scalable and efficient data management <br>• Led development of finance modules, implementing core accounting logic and system workflows <br>• Implemented GST compliance features for Indian operations, ensuring accurate taxation and reporting <br>• Designed and built 15+ accounting and financial reports, improving data visibility and reporting efficiency <br>• Developed statistical reporting features to support business analytics and decision-making <br>• Implemented multi-branch architecture, enabling seamless operations across multiple business units <br>• Built 18+ kitchen management reports covering diet planning, inventory tracking, and operational insights <br>• Performed API testing and validation using Postman and Swagger, ensuring reliability and correctness <br>• Wrote unit tests (AI-assisted) to improve code quality and maintainability <br>• Leveraged AI tools such as Antigravity to enhance development productivity and accelerate implementation <br>• Collaborated on improving system performance, data accuracy, and scalability");
        }
    }
}
