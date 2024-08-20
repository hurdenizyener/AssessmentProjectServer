using Application.Features.Employees.Constans;

namespace Application.Features.Employees.Commands.Create;

public sealed record CreatedEmployeeResponse(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime CreatedDate,
    string Message = EmployeeMessages.EmployeeSuccessfullyCreated);
