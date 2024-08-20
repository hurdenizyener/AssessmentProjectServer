namespace Domain.Common;

public abstract class BaseAuditableEntity(Guid id) : BaseEntity(id)
{
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }

}