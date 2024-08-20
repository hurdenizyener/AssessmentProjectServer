using Application.Common.Pagination.Requests;
using Application.Common.Pagination.Responses;
using Application.Features.Positions.Commands.Create;
using Application.Features.Positions.Commands.Delete;
using Application.Features.Positions.Commands.Update;
using Application.Features.Positions.Queries.GetById;
using Application.Features.Positions.Queries.GetList;
using Application.Features.Positions.Queries.GetAllDepartmentPositions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePositionCommand command)
    {
        CreatedPositionResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePositionCommand command)
    {
        UpdatedPositionResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeletePositionCommand(id);
        DeletedPositionResponse response = await Mediator!.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var getByIdPositionQuery = new GetByIdPositionQuery(id);
        GetByIdPositionResponse response = await Mediator!.Send(getByIdPositionQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int pageIndex, int pageSize)
    {
        var pageRequest = new PageRequest(pageIndex, pageSize);
        var query = new GetListPositionListQuery(pageRequest);
        GetListResponse<GetListPositionListResponse> response = await Mediator!.Send(query);
        return Ok(response);
    }

    [HttpGet("ListByDepartment/{departmentId}")]
    public async Task<IActionResult> GetAllDepartmentPositionsList([FromRoute] Guid departmentId)
    {
        var query = new GetAllDepartmentPositionListQuery(departmentId);
        List<GetAllDepartmentPositionListResponse> response = await Mediator!.Send(query);
        return Ok(response);
    }
}
