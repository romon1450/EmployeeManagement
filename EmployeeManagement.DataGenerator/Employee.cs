namespace EmployeeManagement.DataGenerator;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
    public DateTime DOB { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
    public DateTime? ExitDate { get; set; }
}
