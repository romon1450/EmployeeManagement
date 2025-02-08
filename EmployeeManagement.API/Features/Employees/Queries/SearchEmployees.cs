using Dapper;
using MediatR;
using System.Data;

namespace EmployeeManagement.API.Features.Employees.Queries;

public record SearchEmployeesQuery(string? Name, string? Title) : IRequest<IEnumerable<SearchEmployeesQueryResult>>;
public record SearchEmployeesQueryResult(Guid Id, string Name, DateTime JoinDate, string Title, int Salary);

public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, IEnumerable<SearchEmployeesQueryResult>>
{
    private readonly IDbConnection _connection;

    public SearchEmployeesQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<SearchEmployeesQueryResult>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _connection.QueryAsync<SearchEmployeesQueryResult>(CreateSql(), new { request.Name, request.Title });

        string CreateSql()
        {
            return @"SELECT e.Id,
                            e.Name,
                            e.JoinDate,
                            es.Title,
                            es.Salary
                       FROM dbo.Employee e
                       JOIN dbo.EmployeeSalary es ON es.EmployeeId = e.Id
                      WHERE (@Name IS NULL OR e.Name LIKE '%' + @Name + '%')
                            AND (@Title IS NULL OR es.Title LIKE '%' + @Title + '%')
                           AND es.Id = (
							      SELECT TOP 1 Id
								    FROM dbo.EmployeeSalary 
								   WHERE EmployeeId = e.Id
							    ORDER BY FromDate DESC)";
        }
    }
}