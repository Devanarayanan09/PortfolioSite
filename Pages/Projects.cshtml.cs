using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.Data;

namespace PortfolioSite.Pages
{
    public class ProjectsModel : PageModel
    {
        private readonly PortfolioContext _context;

        public ProjectsModel(PortfolioContext context)
        {
            _context = context;
        }

        public List<Models.Project> Projects { get; set; } = new List<Models.Project>();
        public List<Models.Experience> Experiences { get; set; } = new List<Models.Experience>();
        public int? SelectedExperienceId { get; set; }

        public async Task OnGetAsync(int? experienceId)
        {
            SelectedExperienceId = experienceId;

            // Employers newest first; the side-projects entry goes last.
            Experiences = (await _context.Experiences.ToListAsync())
                .OrderBy(e => e.Company == "Independent Projects")
                .ThenByDescending(e => e.StartDate)
                .ToList();

            var query = _context.Projects
                .Include(p => p.Experience)
                .AsQueryable();

            if (experienceId.HasValue)
            {
                query = query.Where(p => p.ExperienceId == experienceId.Value);
            }

            Projects = (await query.ToListAsync())
                .OrderBy(p => p.Experience?.Company == "Independent Projects")
                .ThenByDescending(p => p.Experience?.StartDate)
                .ThenBy(p => p.Id)
                .ToList();
        }
    }
}
