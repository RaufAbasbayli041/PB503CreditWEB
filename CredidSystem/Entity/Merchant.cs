using CredidSystem.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.Entity
{
    [EntityTypeConfiguration(typeof(MerchantConfigurations))]
    public class Merchant : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Branch> Branches { get; set; } // Navigation property
    }
}
