using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioRedesignContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Projects",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Current resume: experience, projects and technical skills.", "Resume" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Relieving letter from Infosys Limited.");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DocumentType", "Title" },
                values: new object[] { "Certificate of appreciation for progress on assigned tasks and release activities.", "Award", "Infosys Insta Award, Jun 2024" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "DocumentType", "Title" },
                values: new object[] { "Certificate of appreciation for handling the entire PEZA process UAT without issues.", "Award", "Infosys Insta Award, Dec 2024" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Experience letter from Infosys Limited.");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Maintained and enhanced GLOMO and IVISA, two internal enterprise applications for global mobility, visa processing and overseas assignments, each with separate admin and employee portals. Worked across employee declarations, document verification, approval workflows, stored procedures and automated notifications.", "C#, ASP.NET MVC, Entity Framework, ADO.NET, SQL Server" });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Company", "Description", "Technologies" },
                values: new object[] { "Cocopalms Tech Pvt Ltd", "Backend developer on Bizo Suite, a multi-tenant, microservices-based business platform. I build finance, tax and compliance features (GST, XBRL filing, fixed assets, cost centers), reports and dashboards, and the REST APIs and PostgreSQL functions behind them.", ".NET 8, ASP.NET Core Web API, PostgreSQL, Microservices, xUnit" });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Side projects built outside my day job: ASP.NET Core APIs and PostgreSQL databases behind Next.js frontends, built with AI-assisted development.", "ASP.NET Core Web API, PostgreSQL, Next.js, TypeScript" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Summary", "Technologies" },
                values: new object[] { "• Built 5+ employee declarations to client specifications, with document generation and download for admin review <br>• Added support for new visa types by refactoring 20+ SQL Server stored procedures and the related C# logic <br>• Developed the visa process flow for the Philippines and handled the PEZA process UAT end to end <br>• Implemented automated status-update emails, replacing manual notifications to employees", "Internal global mobility application covering employee declarations, visa processes, documents, approvals and notifications.", "ASP.NET MVC, C#, Entity Framework, ADO.NET, SQL Server" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Summary", "Technologies" },
                values: new object[] { "• Built admin features: document download, approval and rejection, and admin workflow stages <br>• Integrated file validation APIs to enforce country-specific document requirements <br>• Implemented automated status-update emails, replacing manual notifications <br>• Traced C# code and stored procedures to assess the impact of each change before modifying it", "Internal application used to administer visa and overseas assignment processes.", "ASP.NET MVC, C#, ADO.NET, SQL Server" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Summary", "Technologies", "Title" },
                values: new object[] { "• Built the XBRL filing module: statement and line-item mapping, taxonomy and note disclosures, validation rules and Arabic line items <br>• Added GST support (HSN/SAC codes, tax preferences, exemptions, TDS settings) across finance, inventory and sales <br>• Built the cost center and fixed-asset modules, with depreciation posted to journal entries and activity logs <br>• Added branch filtering to the finance reports and print-outs <br>• Wrote 18+ kitchen and subscription reports with KPI statistics, plus subscription, operations and CRM dashboards <br>• Moved report and list queries into PostgreSQL functions and tuned them to cut unnecessary database processing <br>• Built the flash offer, purchase request, price list, kitchen settings and branch master APIs <br>• Rolled out database changes across separate per-tenant PostgreSQL databases <br>• Wrote xUnit and Moq tests and verified endpoints with Postman and Swagger", "Business management platform covering finance, accounting, kitchen operations, inventory, subscriptions, sales and delivery.", ".NET 8, ASP.NET Core Web API, PostgreSQL, PL/pgSQL, xUnit, Moq, Swagger", "Bizo Suite" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Summary", "Technologies" },
                values: new object[] { "• Built the ASP.NET Core REST API and PostgreSQL database behind a Next.js 14 frontend <br>• Added English and Malayalam localization, author spotlights and site-wide search <br>• Stored images in cloud object storage (S3) and generated SEO metadata for each page <br>• Built with AI-assisted development", "Bilingual (English and Malayalam) book review and literary archive site with author spotlights.", "ASP.NET Core, PostgreSQL, Next.js 14, TypeScript, S3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "My updated resume with skills and experience", "Professional Resume" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Notice period served");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DocumentType", "Title" },
                values: new object[] { "From Infosys", "Award Certificate", "Award1" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "DocumentType", "Title" },
                values: new object[] { "From Infosys", "Award Certificate", "Award2" });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Experience Letter From Infosys");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Engineered dual-platform solutions (Admin & Employee Portals) for Infosys, streamlining the end-to-end lifecycle of onsite employees. Developed critical systems for document verification, visa processing, and manager approval workflows, ensuring seamless international transitions and landing verification for global talent.", "C#, ASP.NET MVC, SQL Server, .NET Core, ADO.NET" });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Company", "Description", "Technologies" },
                values: new object[] { "Cocopalms Tech Pvt Lmtd", "Spearheading backend development for Cocopalms, a leading Kuwaiti health-tech ecosystem specializing in diet-based food delivery. Developed and maintained several modules of 'Bizo Suite,' a comprehensive accounting engine integrated with their food delivery infrastructure to manage complex financial operations across multiple web and mobile platforms.", "ASP.NET Core Web API, PostgreSQL, Microservices" });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Developing high-performance, modern web applications and digital solutions as an independent developer. Focused on creating seamless user experiences using cutting-edge technologies and best practices in software architecture.", "Next.js, TypeScript, Tailwind CSS, Framer Motion, .NET Core Web API, PostgreSQL" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "• Developed 5+ declarations requiring employee acceptance in line with client specifications, enabling document generation and download functionality of the declarations for admin review. <br>• Configured visa-types by refactoring 20+ stored procedures and application logic. <br>• Implemented automated mailers for status updates, eliminating manual processing entirely. ", "ASP.NET Core, ASP.NET, MVC, SQL Server, Entity Framework" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "• Designed various admin functionalities like document download, approval/rejection, admin stages etc. <br>• Integrated file validation APIs to enforce country-specific document compliance, reducing manual verification by 90%. <br>• Deployed an email notification system that removed all manual status update tasks. ", "ASP.NET, ADO.NET, MVC, SQL Server" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Technologies", "Title" },
                values: new object[] { "• Engineered scalable backend services using .NET Web API and PostgreSQL, implementing business logic, data processing, and reporting capabilities for enterprise applications <br>• Led development of finance modules, implementing core accounting logic and system workflows <br>• Designed and implemented 15+ accounting and financial reports covering financial analysis and accounting operations <br>• Designed and implemented 18+ kitchen management reports covering diet planning, inventory, production, subscriptions, delivery, shop orders, POS orders, and operational KPIs <br>• Developed statistical reporting features to support business analytics and data-driven decision-making <br>• Implemented multi-branch architecture, enabling seamless operations across multiple business units <br>• Worked with a multi-tenant database architecture using separate PostgreSQL databases per tenant, supporting database changes and deployments across multiple tenant environments <br>• Optimized complex SQL queries and PostgreSQL functions to improve reporting performance and reduce unnecessary database processing <br>• Performed API testing and validation using Postman and Swagger, ensuring reliability and correctness <br>• Wrote AI-assisted unit tests to improve code quality, maintainability, and test coverage <br>• Leveraged AI-assisted development and testing tools to accelerate implementation, troubleshoot complex issues, generate test coverage, and improve development productivity", "ASP.NET Core Web API, PostgreSQL, Swagger", "Bizo" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Successfully architected and deployed a high-performance, bilingual (English & Malayalam) literary archive and book discovery platform, fully assisted by the Antigravity AI coding assistant. This production-ready application features a curated database of book reviews and author spotlights, utilizing Full-Stack Development to bridge a React-based frontend with a robust C# Restful API. The project showcases Responsive Web Design with premium glassmorphic aesthetics and Localization (i18n) for seamless script switching. Key technical implementations include Cloud Asset Management for persistent image storage, advanced Search Engine Optimization (SEO) via dynamic metadata generation, and complex State Management to handle real-time global library searches and user-driven content.", "Next.js 14, ASP.NET Core, PostgreSQL, TypeScript, Cloud Asset Management (S3), SEO/Metadata API, RESTful API Design" });
        }
    }
}
