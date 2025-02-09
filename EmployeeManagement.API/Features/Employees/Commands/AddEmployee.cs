using EmployeeManagement.API.Data;
using EmployeeManagement.API.Data.Models;
using MediatR;

namespace EmployeeManagement.API.Features.Employees.Commands;

public record AddEmployeeCommand(string Name, string SSN, DateTime DOB, string Address, string City, string State, string Zip, string Phone, DateTime JoinDate, DateTime? ExitDate, string Title, int Salary) : IRequest;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly EmployeeManagementDbContext _dbContext;

    public AddEmployeeCommandHandler(EmployeeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var newEmployee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            SSN = request.SSN,
            DOB = request.DOB,
            Address = request.Address,
            City = request.City,
            State = request.State,
            Zip = request.Zip,
            Phone = request.Phone,
            JoinDate = request.JoinDate,
            ExitDate = request.ExitDate
        };

        _dbContext.Employees.Add(newEmployee);

        var newEmployeeSalary = new EmployeeSalary
        {
            Id = Guid.NewGuid(),
            EmployeeId = newEmployee.Id,
            FromDate = request.JoinDate,
            ToDate = request.ExitDate,
            Title = request.Title,
            Salary = request.Salary
        };

        _dbContext.EmployeeSalaries.Add(newEmployeeSalary);

        await _dbContext.SaveChangesAsync();
    }
}
