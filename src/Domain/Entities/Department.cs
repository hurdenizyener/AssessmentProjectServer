using Domain.Common;

namespace Domain.Entities;

public sealed class Department : BaseAuditableEntity
{
    public required string Name { get; set; }
    public ISet<Employee> Employees { get; set; } = new HashSet<Employee>();
    public ISet<Position> Positions { get; set; } = new HashSet<Position>();

    public Department() : base(Guid.NewGuid()) { }

    public Department(Guid id, string name) : base(id)
    {
        Id = id;
        Name = name;
        Employees = new HashSet<Employee>();
        Positions = new HashSet<Position>();
    }
}
