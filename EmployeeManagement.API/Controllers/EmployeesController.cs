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

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<SearchEmployeesQueryResult>>> SearchEmployees([FromQuery] SearchEmployeesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("salaries")]
    public async Task<ActionResult<IEnumerable<GetEmployeeSalariesByTitleQueryResult>>> SearchEmployees()
    {
        var result = await _mediator.Send(new GetEmployeeSalariesByTitleQuery());
        return Ok(result);
    }
}
