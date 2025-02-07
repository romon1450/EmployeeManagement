using EmployeeManagement.API.Data.Models;
using EmployeeManagement.API.Data.Models.Configs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data;

public class EmployeeManagementDbContext : DbContext
{
    public EmployeeManagementDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfig).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeSalaryConfig).Assembly);
    }
}
