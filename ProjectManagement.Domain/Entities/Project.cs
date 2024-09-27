using ProjectManagement.Domain.Entities.Base;

namespace ProjectManagement.Domain.Entities;

public class Project : EntityBase
{
    public required string Name { get; set; }
    public required Guid CustomerId { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set;}

    public Customer Customer { get; set; } = null!;
}
