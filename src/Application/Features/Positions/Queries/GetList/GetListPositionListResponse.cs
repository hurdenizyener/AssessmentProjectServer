namespace Application.Features.Positions.Queries.GetList;

public sealed record GetListPositionListResponse(
    Guid Id,
    string DepartmentName,
    string Title,
    DateTime CreatedDate,
    DateTime LastModifiedDate);
