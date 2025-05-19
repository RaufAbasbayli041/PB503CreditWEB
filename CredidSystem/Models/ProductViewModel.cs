using CredidSystem.Entity;
using System.ComponentModel.DataAnnotations;

namespace CredidSystem.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
        public List<IFormFile> Images { get; set; } // For multiple image upload

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; } // Navigation property
        public List<BranchViewModel> Branches { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
