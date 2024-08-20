using Application.Features.Departments.Constans;

namespace Application.Features.Departments.Commands.Create;

public sealed record CreatedDepartmentResponse(
    Guid Id,
    string Name,
    DateTime CreatedDate,
    string Message = DepartmentMessages.DepartmentSuccessfullyCreated);
