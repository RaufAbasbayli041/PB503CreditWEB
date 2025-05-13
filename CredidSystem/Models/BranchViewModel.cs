using System.ComponentModel.DataAnnotations;

namespace CredidSystem.Models
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public int MerchantId { get; set; }
        public MerchantViewModel Merchant { get; set; }
        public List<MerchantViewModel> Merchants { get; set; }
    }
}
