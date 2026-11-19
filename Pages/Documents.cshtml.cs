using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.Data;
using PortfolioSite.Helpers;

namespace PortfolioSite.Pages
{
    public class DocumentsModel : PageModel
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentsModel(PortfolioContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public List<Models.Document> Documents { get; set; } = new List<Models.Document>();

        public async Task OnGetAsync()
        {
            // Resume first, then letters, then awards.
            Documents = (await _context.Documents
                    .Where(d => d.IsPublic)
                    .ToListAsync())
                .OrderBy(d => d.DocumentType.Equals("Resume", StringComparison.OrdinalIgnoreCase) ? 0
                            : d.DocumentType.Contains("Letter", StringComparison.OrdinalIgnoreCase) ? 1
                            : 2)
                .ThenByDescending(d => d.Id)
                .ToList();
        }

        public string GetVersionedFilePath(string relativePath) =>
            ContentHelpers.Versioned(_environment, relativePath);
    }
}
