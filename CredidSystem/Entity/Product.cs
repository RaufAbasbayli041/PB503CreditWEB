using CredidSystem.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.Entity
{
   
    [EntityTypeConfiguration(typeof(ProductConfigurations))]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Navigation property


     //   public Branch Branch { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; } // Navigation property

    }
}
