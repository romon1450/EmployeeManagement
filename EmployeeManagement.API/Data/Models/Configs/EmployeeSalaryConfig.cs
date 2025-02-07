using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data.Models.Configs;

public class EmployeeSalaryConfig : IEntityTypeConfiguration<EmployeeSalary>
{
    public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        builder.ToTable("EmployeeSalary");
        builder.Property(t => t.EmployeeId).IsRequired();
        builder.Property(t => t.Title).HasMaxLength(400);
    }
}