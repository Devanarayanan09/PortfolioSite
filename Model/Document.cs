using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string FilePath { get; set; } = string.Empty;

        [StringLength(50)]
        public string DocumentType { get; set; } = string.Empty; // Resume, Award, Certificate, etc.
        public bool IsPublic { get; set; } = true;
    }
}