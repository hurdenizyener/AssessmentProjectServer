namespace Application.Features.Departments.Queries.GetList;

public sealed record GetListDepartmentListResponse(
    Guid Id,
    string Name,
    DateTime CreatedDate,
    DateTime LastModifiedDate);
