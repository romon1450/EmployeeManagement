using EmployeeManagement.API.Features.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SearchEmployeesQueryResult>>> SearchEmployees(SearchEmployeesQuery query)
    {
        var employees = await _mediator.Send(query);
        return Ok(employees);
    }
}
