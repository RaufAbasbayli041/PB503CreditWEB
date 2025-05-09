using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem.DB
{
    public class CreditWebDB : DbContext
    {
        public CreditWebDB(DbContextOptions<CreditWebDB> options) : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Employee> Employees { get; set; }
       // public DbSet<Customer> Customers { get; set; }
        //public DbSet<Loan> Loans { get; set; }
        //public DbSet<Payment> Payments { get; set; }

       
    }
    
    
}
