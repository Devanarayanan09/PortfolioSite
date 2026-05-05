using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJananthikamContentV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Successfully architected and deployed a high-performance, bilingual (English & Malayalam) literary archive and book discovery platform, fully assisted by the Antigravity AI coding assistant. This production-ready application features a curated database of book reviews and author spotlights, utilizing Full-Stack Development to bridge a React-based frontend with a robust C# Restful API. The project showcases Responsive Web Design with premium glassmorphic aesthetics and Localization (i18n) for seamless script switching. Key technical implementations include Cloud Asset Management for persistent image storage, advanced Search Engine Optimization (SEO) via dynamic metadata generation, and complex State Management to handle real-time global library searches and user-driven content.", "Next.js 14, ASP.NET Core, PostgreSQL (Supabase), TypeScript, Cloud Asset Management (S3), SEO/Metadata API, RESTful API Design" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "• Engineered a premium literary archive platform with a thematic 'book-flip' animation, enhancing the digital reading experience. <br>• Implemented advanced discovery features including fuzzy search across books, authors, and archive directories. <br>• Integrated Supabase Storage for persistent, scalable image management, replacing ephemeral storage solutions. <br>• Developed a comprehensive administrative dashboard for real-time content management and reader engagement tracking.", "Next.js, TypeScript, Supabase, Tailwind CSS, Framer Motion" });
        }
    }
}
