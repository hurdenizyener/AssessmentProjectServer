using Domain.Common;

namespace Domain.Entities;

public sealed class Position : BaseAuditableEntity
{
    public required Guid DepartmentId { get; set; }
    public required string Title { get; set; }

    public Department Department { get; set; } = default!;
    public ISet<Employee> Employees { get; set; } = new HashSet<Employee>();


    public Position() : base(Guid.NewGuid()) { }

    public Position(Guid id, Guid departmentId, string title) : base(id)
    {
        Id = id;
        DepartmentId = departmentId;
        Title = title;
        Employees = new HashSet<Employee>();
    }
}
