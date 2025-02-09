using Dapper;
using EmployeeManagement.DataGenerator;
using IronXL;
using Microsoft.Data.SqlClient;

var workBook = WorkBook.Load(@"employee-test-data.xlsx");
var workSheet = workBook.WorkSheets.First();
var random = new Random();
var today = DateTime.Today;

var dbConnectionString = "Server=localhost;Database=EmployeeManagementDb;Trusted_Connection=true;TrustServerCertificate=true;";
using var connection = new SqlConnection(dbConnectionString);
await connection.OpenAsync();

using var transaction = connection.BeginTransaction();

for (var i = 2; i <= 101; i++)
{
    var employee = new Employee
    {
        Id = Guid.NewGuid(),
        Name = workSheet[$"A{i}"].StringValue,
        SSN = workSheet[$"B{i}"].StringValue,
        DOB = workSheet[$"C{i}"].DateTimeValue.GetValueOrDefault(),
        Address = workSheet[$"D{i}"].StringValue,
        City = workSheet[$"E{i}"].StringValue,
        State = workSheet[$"F{i}"].StringValue,
        Zip = workSheet[$"G{i}"].StringValue,
        Phone = workSheet[$"H{i}"].StringValue
    };

    var minJoinDate = employee.DOB.Date.AddYears(22);
    employee.JoinDate = GetRandomDateInBetween(minJoinDate, today);

    await connection.ExecuteAsync(CreateInsertEmployeeSql(), employee, transaction: transaction);

    var shouldSetExitDate = today.Year - employee.JoinDate.Year > 1 && random.Next(0, 1) == 1;
    if (shouldSetExitDate)
    {
        employee.ExitDate = GetRandomDateInBetween(employee.JoinDate, today);
    }

    var hasWorkedOverTenYears = (employee.ExitDate?.Date.Year ?? today.Year) - employee.JoinDate.Year > 10;
    var salaryCount = hasWorkedOverTenYears ? 3 : 1;
    var salaryFromDate = employee.JoinDate;

    for (var j = 1; j <= salaryCount; j++)
    {
        var randomTitle = Constants.Titles[random.Next(0, Constants.Titles.Count - 1)];
        var randomSalary = Constants.Salaries[random.Next(0, Constants.Salaries.Count - 1)];

        var employeeSalary = new EmployeeSalary
        {
            Id = Guid.NewGuid(),
            EmployeeId = employee.Id,
            FromDate = salaryFromDate,
            Title = randomTitle,
            Salary = randomSalary
        };

        if (j == salaryCount)
        {
            employeeSalary.ToDate = employee.ExitDate;
        }
        else
        {
            employeeSalary.ToDate = GetRandomDateInBetween(salaryFromDate, salaryFromDate.Date.AddYears(4));
            salaryFromDate = employeeSalary.ToDate.Value;
        }

        await connection.ExecuteAsync(CreateInsertEmployeeSalarySql(), employeeSalary, transaction: transaction);
    }
}

transaction.Commit();
workBook.Close();

DateTime GetRandomDateInBetween(DateTime fromDate, DateTime toDate)
{
    var year = random.Next(fromDate.Year + 1, today.Year - 1);
    var month = random.Next(1, 12);
    var day = random.Next(1, 28);

    return new DateTime(year, month, day);
}

string CreateInsertEmployeeSql()
{
    return @"INSERT INTO dbo.Employee (Id, Name, SSN, DOB, Address, City, State, Zip, Phone, JoinDate, ExitDate)
             VALUES (@Id, @Name, @SSN, @DOB, @Address, @City, @State, @Zip, @Phone, @JoinDate, @ExitDate)";
}

string CreateInsertEmployeeSalarySql()
{
    return @"INSERT INTO EmployeeSalary (Id, EmployeeId, FromDate, ToDate, Title, Salary)
	         VALUES (@Id, @EmployeeId, @FromDate, @ToDate, @Title, @Salary)";
}