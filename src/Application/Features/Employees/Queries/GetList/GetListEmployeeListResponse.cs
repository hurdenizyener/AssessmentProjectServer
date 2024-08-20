namespace Application.Features.Employees.Queries.GetList;

public sealed record GetListEmployeeListResponse(
    Guid Id,
    Guid DepartmentId,
    string DepartmentName,
    Guid PositionId,
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
