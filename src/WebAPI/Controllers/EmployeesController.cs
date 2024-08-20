using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Features.Employees.Commands.Create;
using Application.Features.Employees.Commands.Delete;
using Application.Features.Employees.Commands.Update;
using Application.Features.Employees.Commands.UpdateStatus;
using Application.Features.Employees.Queries.GetById;
using Application.Features.Employees.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEmployeeCommand command)
    {
        CreatedEmployeeResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand command)
    {
        UpdatedEmployeeResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusCommand command)
    {
        UpdatedStatusResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteEmployeeCommand(id);
        DeletedEmployeeResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var getByIdEmployeeQuery = new GetByIdEmployeeQuery(id);
        GetByIdEmployeeResponse response = await Mediator!.Send(getByIdEmployeeQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int pageIndex, int pageSize)
    {
        var pageRequest = new PageRequest(pageIndex, pageSize);
        var query = new GetListEmployeeListQuery(pageRequest);
        GetListResponse<GetListEmployeeListResponse> response = await Mediator!.Send(query);
        return Ok(response);
    }
}
