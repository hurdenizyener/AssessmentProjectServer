using Domain.Common;

namespace Domain.Entities;

public sealed class Employee : BaseAuditableEntity
{
    public required Guid DepartmentId { get; set; }
    public required Guid PositionId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Gender { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required string GraduatedSchool { get; set; }
    public required string GraduatedField { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime DateOfEntry { get; set; }
    public bool Asset { get; set; }
    public string? Address { get; set; } = default!;
    public bool Status { get; set; }

    public Department Department { get; set; } = default!;
    public Position Position { get; set; } = default!;

    public Employee() : base(Guid.NewGuid()) { }

    public Employee(Guid id, Guid departmentId, Guid positionId, string firstName, string lastName, string gender, string phone, string email, string graduatedSchool, string graduatedField, DateTime birthDate, DateTime dateOfEntry, bool asset, string? address, bool status) : base(id)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Phone = phone;
        Email = email;
        GraduatedSchool = graduatedSchool;
        GraduatedField = graduatedField;
        BirthDate = birthDate;
        DateOfEntry = dateOfEntry;
        Asset = asset;
        Address = address;
        Status = status;
    }
}
