using Dapper;
using MediatR;
using System.Data;

namespace EmployeeManagement.API.Features.Employees.Queries;

public record GetEmployeeSalariesByTitleQuery : IRequest<IEnumerable<GetEmployeeSalariesByTitleQueryResult>>;
public record GetEmployeeSalariesByTitleQueryResult(string Title, int MaxSalary, int MinSalary);

public class GetEmployeeSalariesByTitleQueryHandler : IRequestHandler<GetEmployeeSalariesByTitleQuery, IEnumerable<GetEmployeeSalariesByTitleQueryResult>>
{
    private readonly IDbConnection _connection;

    public GetEmployeeSalariesByTitleQueryHandler(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<GetEmployeeSalariesByTitleQueryResult>> Handle(GetEmployeeSalariesByTitleQuery request, CancellationToken cancellationToken)
    {
        return await _connection.QueryAsync<GetEmployeeSalariesByTitleQueryResult>(CreateSql());

        string CreateSql()
        {
            return @"SELECT es.Title, 
                            MAX(es.Salary) AS MaxSalary, 
                            MIN(es.Salary) AS MinSalary
                       FROM dbo.EmployeeSalary es
                   GROUP BY es.Title
                   ORDER BY es.Title";
        }
    }
}