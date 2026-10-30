using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.Data;

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
            Documents = await _context.Documents
                .Where(d => d.IsPublic)
                .OrderByDescending(d => d.Id)
                .ToListAsync();
        }

        public string GetVersionedFilePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return relativePath;

            var webRoot = _environment.WebRootPath;
            if (string.IsNullOrEmpty(webRoot))
            {
                webRoot = Path.Combine(_environment.ContentRootPath, "wwwroot");
            }

            var fullPath = Path.Combine(webRoot, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            if (System.IO.File.Exists(fullPath))
            {
                var ticks = System.IO.File.GetLastWriteTimeUtc(fullPath).Ticks;
                return $"{relativePath}?v={ticks}";
            }
            return relativePath;
        }
    }
}