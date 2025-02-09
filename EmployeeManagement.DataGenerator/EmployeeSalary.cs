namespace EmployeeManagement.DataGenerator;

public class EmployeeSalary
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public int Salary { get; set; }
}
