using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class Experience
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Company { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrent { get; set; }

        [StringLength(100)]
        public string Technologies { get; set; } = string.Empty;

        // Navigation property for projects related to this experience
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}