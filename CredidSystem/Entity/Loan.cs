using CredidSystem.Enum.LoanStatus;

namespace CredidSystem.Entity
{
    public class Loan : BaseEntity
    {
        public LoanStatus LoanStatus { get; set; } // Enum for loan status

        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; } // Navigation property
    
       
        public decimal Amount { get; set; }
        
    }
}
