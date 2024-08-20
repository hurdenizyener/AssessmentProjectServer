using Application.Features.Departments.Constans;

namespace Application.Features.Departments.Commands.Update;

public sealed record UpdatedDepartmentResponse(
    Guid Id,
    string Name,
    DateTime LastModifiedDate,
    string Message = DepartmentMessages.DepartmentSuccessfullyUpdated);
