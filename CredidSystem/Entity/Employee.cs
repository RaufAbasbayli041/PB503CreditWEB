using CredidSystem.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CredidSystem.Entity
{
    [EntityTypeConfiguration(typeof(EmployeeConfigurations))]
    public class Employee : Person
    {
       
        public string Position { get; set; }
        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; } // Navigation property

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public ICollection<Loan> Loans { get; set; } 


    }

}
