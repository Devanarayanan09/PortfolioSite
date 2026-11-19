using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class AddDropSpikeProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Side projects built outside my day job: DropSpike, a Flutter productivity app for Android, and Jananthikam, an ASP.NET Core and PostgreSQL backend behind a Next.js site. Both built with AI-assisted development.", "Flutter, Dart, SQLite, ASP.NET Core Web API, PostgreSQL, Next.js" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ExperienceId", "ImageUrl", "IsFeatured", "ProjectUrl", "Summary", "Technologies", "Title" },
                values: new object[] { 5, "• Built habit tracking with streaks, expense and budget tracking, borrowed-money records and a to-do list with reminders and natural-language task entry <br>• Added a focus timer with ambient soundscapes and a Reel Blocker that limits Shorts and Reels per session or per day <br>• Added analytics for habits, spending, focus and screen time, plus a home-screen widget <br>• Stored all data on the device in SQLite, with data export and sharing <br>• Integrated in-app purchases for a premium tier, in-app updates and review prompts, and Shorebird code push for over-the-air fixes <br>• Built with AI-assisted development", 3, "", true, "https://play.google.com/store/apps/details?id=com.jananthikam.dropspike", "Flutter productivity app for Android that brings habits, expenses, to-dos and focused work into one app.", "Flutter, Dart, SQLite (sqflite), Provider, In-app purchases, Shorebird", "DropSpike" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Technologies" },
                values: new object[] { "Side projects built outside my day job: ASP.NET Core APIs and PostgreSQL databases behind Next.js frontends, built with AI-assisted development.", "ASP.NET Core Web API, PostgreSQL, Next.js, TypeScript" });
        }
    }
}
