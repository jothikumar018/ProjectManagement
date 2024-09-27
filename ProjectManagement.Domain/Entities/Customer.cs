using ProjectManagement.Domain.Entities.Base;

namespace ProjectManagement.Domain.Entities;

public class Customer : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }
    public bool IsActive { get; set; }
    public List<Project> Projects { get; set; } = new();
}
