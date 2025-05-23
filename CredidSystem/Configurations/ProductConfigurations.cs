using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredidSystem.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
          
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            
            builder.HasOne(e => e.Branch).WithMany().HasForeignKey(w => w.BranchId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(e => e.Category).WithMany().HasForeignKey(w => w.CategoryId).OnDelete(DeleteBehavior.NoAction);


        }

       
    }
    
}
