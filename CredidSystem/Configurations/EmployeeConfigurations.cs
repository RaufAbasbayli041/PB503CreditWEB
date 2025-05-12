using CredidSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CredidSystem.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {          
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.DateOfBirth).IsRequired();
            builder.Property(e => e.Position).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Salary).IsRequired().HasColumnType("decimal(10,2)");
            builder.HasOne(e => e.Branch)
                   .WithMany(b => b.Employees)
                   .HasForeignKey(e => e.BranchId).OnDelete(DeleteBehavior.NoAction);
        }
    }
    
    
}
