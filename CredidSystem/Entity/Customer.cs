namespace CredidSystem.Entity
{
    public class Customer : Person
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; } // Navigation property


    }
}
