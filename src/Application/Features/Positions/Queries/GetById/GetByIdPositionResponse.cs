namespace Application.Features.Positions.Queries.GetById;

public sealed record GetByIdPositionResponse(
    Guid Id,
    string DepartmentName,
    string Title,
    DateTime CreatedDate,
    DateTime LastModifiedDate);
