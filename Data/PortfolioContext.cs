using Microsoft.EntityFrameworkCore;
using PortfolioSite.Models;

namespace PortfolioSite.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    Company = "Infosys Limited",
                    Position = "Senior Systems Engineer",
                    Description = "Maintained and enhanced GLOMO and IVISA, two internal enterprise applications for global mobility, visa processing and overseas assignments, each with separate admin and employee portals. Worked across employee declarations, document verification, approval workflows, stored procedures and automated notifications.",
                    StartDate = new DateTime(2022, 3, 24),
                    EndDate = new DateTime(2025, 7, 29),
                    IsCurrent = false,
                    Technologies = "C#, ASP.NET MVC, Entity Framework, ADO.NET, SQL Server",
                },
                new Experience
                {
                    Id = 2,
                    Company = "Cocopalms Tech Pvt Ltd",
                    Position = "Senior Backend Developer",
                    Description = "Backend developer on Bizo Suite, a multi-tenant, microservices-based business platform. I build finance, tax and compliance features (GST, XBRL filing, fixed assets, cost centers), reports and dashboards, and the REST APIs and PostgreSQL functions behind them.",
                    StartDate = new DateTime(2025, 12, 2),
                    IsCurrent = true,
                    Technologies = ".NET 8, ASP.NET Core Web API, PostgreSQL, Microservices, xUnit",
                },
                new Experience
                {
                    Id = 3,
                    Company = "Independent Projects",
                    Position = "Full Stack Developer",
                    Description = "Side projects built outside my day job: DropSpike, a Flutter productivity app for Android, and Jananthikam, an ASP.NET Core and PostgreSQL backend behind a Next.js site. Both built with AI-assisted development.",
                    StartDate = new DateTime(2024, 1, 1),
                    IsCurrent = true,
                    Technologies = "Flutter, Dart, SQLite, ASP.NET Core Web API, PostgreSQL, Next.js",
                }
            );

            // Seed projects linked to experiences
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "GLOMO",
                    Summary = "Internal global mobility application covering employee declarations, visa processes, documents, approvals and notifications.",
                    Description = "• Built 5+ employee declarations to client specifications, with document generation and download for admin review <br>• Added support for new visa types by refactoring 20+ SQL Server stored procedures and the related C# logic <br>• Developed the visa process flow for the Philippines and handled the PEZA process UAT end to end <br>• Implemented automated status-update emails, replacing manual notifications to employees",
                    ImageUrl = "/images/Projects/GLOMO.jpg",
                    ProjectUrl = "",
                    Technologies = "ASP.NET MVC, C#, Entity Framework, ADO.NET, SQL Server",
                    IsFeatured = true,
                    ExperienceId = 1
                },
                new Project
                {
                    Id = 2,
                    Title = "IVISA",
                    Summary = "Internal application used to administer visa and overseas assignment processes.",
                    Description = "• Built admin features: document download, approval and rejection, and admin workflow stages <br>• Integrated file validation APIs to enforce country-specific document requirements <br>• Implemented automated status-update emails, replacing manual notifications <br>• Traced C# code and stored procedures to assess the impact of each change before modifying it",
                    ImageUrl = "/images/Projects/GLOMO.jpg",
                    ProjectUrl = "",
                    Technologies = "ASP.NET MVC, C#, ADO.NET, SQL Server",
                    IsFeatured = true,
                    ExperienceId = 1
                },
                new Project
                {
                    Id = 3,
                    Title = "Bizo Suite",
                    Summary = "Business management platform covering finance, accounting, kitchen operations, inventory, subscriptions, sales and delivery.",
                    Description = "• Built the XBRL filing module: statement and line-item mapping, taxonomy and note disclosures, validation rules and Arabic line items <br>• Added GST support (HSN/SAC codes, tax preferences, exemptions, TDS settings) across finance, inventory and sales <br>• Built the cost center and fixed-asset modules, with depreciation posted to journal entries and activity logs <br>• Added branch filtering to the finance reports and print-outs <br>• Wrote 18+ kitchen and subscription reports with KPI statistics, plus subscription, operations and CRM dashboards <br>• Moved report and list queries into PostgreSQL functions and tuned them to cut unnecessary database processing <br>• Built the flash offer, purchase request, price list, kitchen settings and branch master APIs <br>• Rolled out database changes across separate per-tenant PostgreSQL databases <br>• Wrote xUnit and Moq tests and verified endpoints with Postman and Swagger",
                    ImageUrl = "/images/Projects/Cocopalms.png",
                    ProjectUrl = "https://bizosuite.com/",
                    Technologies = ".NET 8, ASP.NET Core Web API, PostgreSQL, PL/pgSQL, xUnit, Moq, Swagger",
                    IsFeatured = true,
                    ExperienceId = 2
                },
                new Project
                {
                    Id = 4,
                    Title = "Jananthikam",
                    Summary = "Bilingual (English and Malayalam) book review and literary archive site with author spotlights.",
                    Description = "• Built the ASP.NET Core REST API and PostgreSQL database behind a Next.js 14 frontend <br>• Added English and Malayalam localization, author spotlights and site-wide search <br>• Stored images in cloud object storage (S3) and generated SEO metadata for each page <br>• Built with AI-assisted development",
                    ImageUrl = "/images/Projects/Jananthikam.jpg",
                    ProjectUrl = "https://jananthikam.com/",
                    Technologies = "ASP.NET Core, PostgreSQL, Next.js 14, TypeScript, S3",
                    IsFeatured = true,
                    ExperienceId = 3
                },
                new Project
                {
                    Id = 5,
                    Title = "DropSpike",
                    Summary = "Flutter productivity app for Android that brings habits, expenses, to-dos and focused work into one app.",
                    Description = "• Built habit tracking with streaks, expense and budget tracking, borrowed-money records and a to-do list with reminders and natural-language task entry <br>• Added a focus timer with ambient soundscapes and a Reel Blocker that limits Shorts and Reels per session or per day <br>• Added analytics for habits, spending, focus and screen time, plus a home-screen widget <br>• Stored all data on the device in SQLite, with data export and sharing <br>• Integrated in-app purchases for a premium tier, in-app updates and review prompts, and Shorebird code push for over-the-air fixes <br>• Built with AI-assisted development",
                    ImageUrl = "",
                    ProjectUrl = "https://play.google.com/store/apps/details?id=com.jananthikam.dropspike",
                    Technologies = "Flutter, Dart, SQLite (sqflite), Provider, In-app purchases, Shorebird",
                    IsFeatured = true,
                    ExperienceId = 3
                }
            );

            modelBuilder.Entity<Document>().HasData(
                new Document
                {
                    Id = 1,
                    Title = "Resume",
                    Description = "Current resume: experience, projects and technical skills.",
                    FilePath = "/images/Documents/Resume.pdf",
                    DocumentType = "Resume",
                    IsPublic = true
                },
                new Document
                {
                    Id = 2,
                    Title = "Relieving Letter",
                    Description = "Relieving letter from Infosys Limited.",
                    FilePath = "/images/Documents/Relieving Letter.pdf",
                    DocumentType = "Relieving Letter",
                    IsPublic = true
                },
                new Document
                {
                    Id = 3,
                    Title = "Infosys Insta Award, Jun 2024",
                    Description = "Certificate of appreciation for progress on assigned tasks and release activities.",
                    FilePath = "/images/Documents/Award1.png",
                    DocumentType = "Award",
                    IsPublic = true
                },
                new Document
                {
                    Id = 4,
                    Title = "Infosys Insta Award, Dec 2024",
                    Description = "Certificate of appreciation for handling the entire PEZA process UAT without issues.",
                    FilePath = "/images/Documents/Award2.png",
                    DocumentType = "Award",
                    IsPublic = true
                },
                new Document
                {
                    Id = 5,
                    Title = "Experience Letter",
                    Description = "Experience letter from Infosys Limited.",
                    FilePath = "/images/Documents/Experience_Letter.pdf",
                    DocumentType = "Experience Letter",
                    IsPublic = true
                }
            );
        }
    }
}
