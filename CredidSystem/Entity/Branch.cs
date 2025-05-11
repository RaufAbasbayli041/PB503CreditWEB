using CredidSystem.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CredidSystem.Entity
{
    [EntityTypeConfiguration(typeof(BrancesConfigurations))]
    public class Branch : BaseEntity
    {       
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; } // Navigation property

        public ICollection<Employee> Employees { get; set; } // Navigation property
    }
}
