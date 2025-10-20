using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentSeed5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Description", "DocumentType", "FilePath", "IsPublic", "Title" },
                values: new object[] { 5, "Experience Letter From Infosys", "Experience Letter", "/images/Documents/Experience_Letter.pdf", true, "Experience Letter" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
