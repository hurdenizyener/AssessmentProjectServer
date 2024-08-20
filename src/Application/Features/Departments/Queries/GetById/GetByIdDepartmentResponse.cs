namespace Application.Features.Departments.Queries.GetById;

public sealed record GetByIdDepartmentResponse(
    Guid Id,
    string Name,
    DateTime CreatedDate,
    DateTime LastModifiedDate);
