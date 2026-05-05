using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class AddJananthikamProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Company", "Description", "EndDate", "IsCurrent", "Position", "StartDate", "Technologies" },
                values: new object[] { 3, "Independent Projects", "Developing high-performance, modern web applications and digital solutions as an independent developer. Focused on creating seamless user experiences using cutting-edge technologies and best practices in software architecture.", null, true, "Full Stack Developer", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Next.js, TypeScript, Supabase, Tailwind CSS, Framer Motion" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ExperienceId", "ImageUrl", "IsFeatured", "ProjectUrl", "Technologies", "Title" },
                values: new object[] { 4, "• Engineered a premium literary archive platform with a thematic 'book-flip' animation, enhancing the digital reading experience. <br>• Implemented advanced discovery features including fuzzy search across books, authors, and archive directories. <br>• Integrated Supabase Storage for persistent, scalable image management, replacing ephemeral storage solutions. <br>• Developed a comprehensive administrative dashboard for real-time content management and reader engagement tracking.", 3, "/images/Projects/Jananthikam.jpg", true, "https://jananthikam.com/", "Next.js, TypeScript, Supabase, Tailwind CSS, Framer Motion", "Jananthikam" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
