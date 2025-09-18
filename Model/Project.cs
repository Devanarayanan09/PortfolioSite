using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [StringLength(200)]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(200)]
        public string ProjectUrl { get; set; } = string.Empty;

        [StringLength(100)]
        public string Technologies { get; set; } = string.Empty;

        public bool IsFeatured { get; set; }

        // Foreign key for experience
        public int? ExperienceId { get; set; }
        public Experience? Experience { get; set; }
    }
}