namespace Application.Features.Departments.Queries.GetAll;

public sealed record GetAllDepartmentListResponse(
    Guid Id,
    string Name,
    DateTime CreatedDate,
    DateTime LastModifiedDate);
