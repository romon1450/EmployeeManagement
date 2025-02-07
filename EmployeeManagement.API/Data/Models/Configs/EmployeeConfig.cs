using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data.Models.Configs;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.Property(t => t.Name).HasMaxLength(200);
        builder.Property(t => t.SSN).HasMaxLength(50);
        builder.Property(t => t.Address).HasMaxLength(400);
        builder.Property(t => t.City).HasMaxLength(200);
        builder.Property(t => t.State).HasMaxLength(50);
        builder.Property(t => t.Zip).HasMaxLength(50);
        builder.Property(t => t.Phone).HasMaxLength(50);
    }
}
