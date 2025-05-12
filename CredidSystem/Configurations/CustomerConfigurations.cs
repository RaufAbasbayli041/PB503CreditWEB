using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredidSystem.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(a => a.Loan)
                   .WithOne()
                   .HasForeignKey<Customer>(o => o.LoanId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
