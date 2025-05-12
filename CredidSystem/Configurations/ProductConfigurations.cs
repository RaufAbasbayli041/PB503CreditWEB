using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredidSystem.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.HasOne(e => e.Loan)
                   .WithOne()
                   .HasForeignKey<Product>(e => e.LoanId).OnDelete(DeleteBehavior.NoAction);
          
        }

       
    }
    
}
