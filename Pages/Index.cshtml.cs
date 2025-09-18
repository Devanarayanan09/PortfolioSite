using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.Data;
using PortfolioSite.Models;

namespace PortfolioSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PortfolioContext _context;

        public IndexModel(PortfolioContext context)
        {
            _context = context;
        }

        public List<Experience> Experiences { get; set; } = new List<Experience>();
        public List<Project> FeaturedProjects { get; set; } = new List<Project>();

        public async Task OnGetAsync()
        {
            Experiences = await _context.Experiences
                .Include(e => e.Projects)
                .OrderByDescending(e => e.StartDate)
                .ToListAsync();

            FeaturedProjects = await _context.Projects
                .Where(p => p.IsFeatured)
                .OrderByDescending(p => p.Id)
                .Take(3)
                .ToListAsync();
        }
    }
}