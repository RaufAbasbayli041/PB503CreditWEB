using System.ComponentModel.DataAnnotations;

namespace CredidSystem.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
      
        [Required]
        public List<ProductViewModel> Products { get; set; } // Navigation property
        public List<BranchViewModel> Branches { get; set; } // Navigation property
    }
}
