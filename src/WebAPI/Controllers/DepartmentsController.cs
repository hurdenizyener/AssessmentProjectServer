using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetAll;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDepartmentCommand command)
    {
        CreatedDepartmentResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDepartmentCommand command)
    {
        UpdatedDepartmentResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteDepartmentCommand(id);
        DeletedDepartmentResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var getByIdDepartmentQuery = new GetByIdDepartmentQuery(id);
        GetByIdDepartmentResponse response = await Mediator!.Send(getByIdDepartmentQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int pageIndex, int pageSize)
    {
        var pageRequest = new PageRequest(pageIndex, pageSize);
        var query = new GetListDepartmentListQuery(pageRequest);
        GetListResponse<GetListDepartmentListResponse> response = await Mediator!.Send(query);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllDepartmentListQuery();
        List<GetAllDepartmentListResponse> response = await Mediator!.Send(query);
        return Ok(response);
    }
}
