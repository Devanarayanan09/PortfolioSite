using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioSite.Data;
using PortfolioSite.Models;

namespace PortfolioSite.Pages
{
    public class ContactModel : PageModel
    {
        private readonly PortfolioContext _context;
        private readonly IConfiguration _configuration;

        public ContactModel(PortfolioContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [BindProperty]
        public ContactMessage Message { get; set; } = new ContactMessage();

        public void OnGet()
        {
        }

    }
}