namespace ProjectManagement.Domain.Entities.Base;

public abstract class EntityBase
{
    public required Guid Id { get; set; }
    public required Guid TenantId { get; set; }
    public bool IsDeleted { get; set; }
    public required Guid CreatedBy { get; set; }
    public required DateTimeOffset CreatedDate { get; set; }
    public required Guid ModifiedBy { get; set; }
    public required DateTimeOffset ModifiedDate { get; set; }
}
