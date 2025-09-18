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
    }
}