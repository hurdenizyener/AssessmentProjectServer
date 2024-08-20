namespace Application.Features.Employees.Queries.GetById;


public sealed record GetByIdEmployeeResponse(
    Guid Id,
    string DepartmentName,
    string PositionTitle,
    string FirstName,
    string LastName,
    string Gender,
    string Phone,
    string Email,
    string GraduatedSchool,
    string GraduatedField,
    DateTime BirthDate,
    DateTime DateOfEntry,
    bool Asset,
    string Address,
    bool Status,
    DateTime CreatedDate,
    DateTime LastModifiedDate);
