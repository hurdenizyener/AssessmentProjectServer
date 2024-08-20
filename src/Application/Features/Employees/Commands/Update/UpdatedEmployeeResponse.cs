using Application.Features.Employees.Constans;

namespace Application.Features.Employees.Commands.Update;

public sealed record UpdatedEmployeeResponse(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime LastModifiedDate,
    string Message = EmployeeMessages.EmployeeSuccessfullyUpdated);
