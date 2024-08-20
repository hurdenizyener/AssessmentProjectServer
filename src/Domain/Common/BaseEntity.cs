namespace Domain.Common;

public abstract class BaseEntity(Guid Id)
{
    public Guid Id { get; set; } = Id == Guid.Empty ? Guid.NewGuid() : Id;
}
