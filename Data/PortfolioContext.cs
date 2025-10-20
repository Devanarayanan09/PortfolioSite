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
            // Seed sample experiences
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    Company = "Infosys Limited",
                    Position = "Senior Systems Engineer",
                    Description = "In charge of designing, developing, maintaining, and deploying scalable web applications using ASP.NET MVC, with active involvement in release management to test and production environments.",
                    StartDate = new DateTime(2022, 3, 24),
                    EndDate = new DateTime(2025, 7, 29),
                    IsCurrent = false,
                    Technologies = "C#, ASP.NET MVC, SQL Server, .NET Core, ADO.NET",
                }
            );

            // Seed sample projects linked to experiences
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "GLOMO",
                    Description = "• Developed 5+ declarations requiring employee acceptance in line with client specifications, enabling document generation and download functionality of the declarations for admin review. <br>• Configured visa-types by refactoring 20+ stored procedures and application logic. <br>• Implemented automated mailers for status updates, eliminating manual processing entirely. ",
                    ImageUrl = "/images/Projects/GLOMO.png",
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
                    ImageUrl = "/images/Projects/IVISA.png",
                    ProjectUrl = "",
                    Technologies = "ASP.NET, ADO.NET, MVC, SQL Server",
                    IsFeatured = true,
                    ExperienceId = 1
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