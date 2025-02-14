using EmployeeManagement.API.Features.Employees.Commands;
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
    public async Task<ActionResult<IEnumerable<GetEmployeeSalariesByTitleQueryResult>>> GetEmployeeSalariesByTitle()
    {
        var result = await _mediator.Send(new GetEmployeeSalariesByTitleQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(AddEmployeeCommand command)
    {
        await _mediator.Send(command);
        return Created();
    }
}
