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
            // Employers newest first; the side-projects entry goes last.
            Experiences = (await _context.Experiences
                    .Include(e => e.Projects)
                    .ToListAsync())
                .OrderBy(e => e.Company == "Independent Projects")
                .ThenByDescending(e => e.StartDate)
                .ToList();

            // Professional work first (most recent employer first), side projects last.
            var projects = await _context.Projects
                .Include(p => p.Experience)
                .Where(p => p.IsFeatured)
                .ToListAsync();

            FeaturedProjects = projects
                .OrderBy(p => p.Experience?.Company == "Independent Projects")
                .ThenByDescending(p => p.Experience?.StartDate)
                .ThenBy(p => p.Id)
                .ToList();
        }
    }
}
