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
                    Description = "Engineered dual-platform solutions (Admin & Employee Portals) for Infosys, streamlining the end-to-end lifecycle of onsite employees. Developed critical systems for document verification, visa processing, and manager approval workflows, ensuring seamless international transitions and landing verification for global talent.",
                    StartDate = new DateTime(2022, 3, 24),
                    EndDate = new DateTime(2025, 7, 29),
                    IsCurrent = false,
                    Technologies = "C#, ASP.NET MVC, SQL Server, .NET Core, ADO.NET",
                },
                new Experience
                {
                    Id = 2,
                    Company = "Cocopalms Tech Pvt Lmtd",
                    Position = "Senior Backend Developer",
                    Description = "Spearheading backend development for Cocopalms, a leading Kuwaiti health-tech ecosystem specializing in diet-based food delivery. Developed and maintained several modules of 'Bizo Suite,' a comprehensive accounting engine integrated with their food delivery infrastructure to manage complex financial operations across multiple web and mobile platforms.",
                    StartDate = new DateTime(2025, 12, 2),
                    IsCurrent = true,
                    Technologies = "ASP.NET Core Web API, PostgreSQL, Microservices",
                },
                new Experience
                {
                    Id = 3,
                    Company = "Independent Projects",
                    Position = "Full Stack Developer",
                    Description = "Developing high-performance, modern web applications and digital solutions as an independent developer. Focused on creating seamless user experiences using cutting-edge technologies and best practices in software architecture.",
                    StartDate = new DateTime(2024, 1, 1),
                    IsCurrent = true,
                    Technologies = "Next.js, TypeScript, Tailwind CSS, Framer Motion, .NET Core Web API, PostgreSQL",
                }
            );

            // Seed sample projects linked to experiences
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "GLOMO",
                    Description = "• Developed 5+ declarations requiring employee acceptance in line with client specifications, enabling document generation and download functionality of the declarations for admin review. <br>• Configured visa-types by refactoring 20+ stored procedures and application logic. <br>• Implemented automated mailers for status updates, eliminating manual processing entirely. ",
                    ImageUrl = "/images/Projects/GLOMO.jpg",
                    ProjectUrl = "",
                    Technologies = "ASP.NET Core, ASP.NET, MVC, SQL Server, Entity Framework",
                    IsFeatured = true,
                    ExperienceId = 1
                },
                new Project
                {
                    Id = 2,
                    Title = "IVISA",
                    Description = "• Designed various admin functionalities like document download, approval/rejection, admin stages etc. <br>• Integrated file validation APIs to enforce country-specific document compliance, reducing manual verification by 90%. <br>• Deployed an email notification system that removed all manual status update tasks. ",
                    ImageUrl = "/images/Projects/GLOMO.jpg",
                    ProjectUrl = "",
                    Technologies = "ASP.NET, ADO.NET, MVC, SQL Server",
                    IsFeatured = true,
                    ExperienceId = 1
                },
                new Project
                {
                    Id = 3,
                    Title = "Bizo",
                    Description = "• Developed backend services using .NET Web API with PostgreSQL for scalable and efficient data management <br>• Led development of finance modules, implementing core accounting logic and system workflows <br>• Implemented GST compliance features for Indian operations, ensuring accurate taxation and reporting <br>• Designed and built 15+ accounting and financial reports, improving data visibility and reporting efficiency <br>• Developed statistical reporting features to support business analytics and decision-making <br>• Implemented multi-branch architecture, enabling seamless operations across multiple business units <br>• Built 18+ kitchen management reports covering diet planning, inventory tracking, and operational insights <br>• Performed API testing and validation using Postman and Swagger, ensuring reliability and correctness <br>• Wrote unit tests (AI-assisted) to improve code quality and maintainability <br>• Leveraged AI tools such as Antigravity to enhance development productivity and accelerate implementation <br>• Collaborated on improving system performance, data accuracy, and scalability",
                    ImageUrl = "/images/Projects/Cocopalms.png",
                    ProjectUrl = "https://bizosuite.com/",
                    Technologies = "ASP.NET Core Web API, PostgreSQL, Swagger",
                    IsFeatured = true,
                    ExperienceId = 2
                },
                new Project
                {
                    Id = 4,
                    Title = "Jananthikam",
                    Description = "Successfully architected and deployed a high-performance, bilingual (English & Malayalam) literary archive and book discovery platform, fully assisted by the Antigravity AI coding assistant. This production-ready application features a curated database of book reviews and author spotlights, utilizing Full-Stack Development to bridge a React-based frontend with a robust C# Restful API. The project showcases Responsive Web Design with premium glassmorphic aesthetics and Localization (i18n) for seamless script switching. Key technical implementations include Cloud Asset Management for persistent image storage, advanced Search Engine Optimization (SEO) via dynamic metadata generation, and complex State Management to handle real-time global library searches and user-driven content.",
                    ImageUrl = "/images/Projects/Jananthikam.jpg",
                    ProjectUrl = "https://jananthikam.com/",
                    Technologies = "Next.js 14, ASP.NET Core, PostgreSQL, TypeScript, Cloud Asset Management (S3), SEO/Metadata API, RESTful API Design",
                    IsFeatured = true,
                    ExperienceId = 3
                }
            );

            modelBuilder.Entity<Document>().HasData(
                new Document
                {
                    Id = 1,
                    Title = "Professional Resume",
                    Description = "My updated resume with skills and experience",
                    FilePath = "/images/Documents/Resume.pdf",
                    DocumentType = "Resume",
                    IsPublic = true
                },
                new Document
                {
                    Id = 2,
                    Title = "Relieving Letter",
                    Description = "Notice period served",
                    FilePath = "/images/Documents/Relieving Letter.pdf",
                    DocumentType = "Relieving Letter",
                    IsPublic = true
                },
                new Document
                {
                    Id = 3,
                    Title = "Award1",
                    Description = "From Infosys",
                    FilePath = "/images/Documents/Award1.png",
                    DocumentType = "Award Certificate",
                    IsPublic = true
                },
                new Document
                {
                    Id = 4,
                    Title = "Award2",
                    Description = "From Infosys",
                    FilePath = "/images/Documents/Award2.png",
                    DocumentType = "Award Certificate",
                    IsPublic = true
                },
                new Document
                {
                    Id = 5,
                    Title = "Experience Letter",
                    Description = "Experience Letter From Infosys",
                    FilePath = "/images/Documents/Experience_Letter.pdf",
                    DocumentType = "Experience Letter",
                    IsPublic = true
                }
            );
        }
    }
}