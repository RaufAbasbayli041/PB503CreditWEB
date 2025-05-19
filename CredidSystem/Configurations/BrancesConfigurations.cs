using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredidSystem.Configurations
{
    public class BrancesConfigurations : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
           
            builder.Property(a=>a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a=>a.Address).IsRequired().HasMaxLength(100);
            builder.Property(b => b.PhoneNumber).IsRequired();
            builder.HasOne(a=>a.Merchant).WithMany(q=>q.Branches).HasForeignKey(o=>o.MerchantId).OnDelete(DeleteBehavior.NoAction);          
        }
    }
}
