using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredidSystem.Configurations
{
    public class MerchantConfigurations : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(50);
            builder.HasMany(e => e.Branches)
                   .WithOne(b => b.Merchant)
                   .HasForeignKey(e => e.MerchantId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
