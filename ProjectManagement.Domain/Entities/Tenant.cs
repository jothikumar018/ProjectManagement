using ProjectManagement.Domain.Entities.Base;

namespace ProjectManagement.Domain.Entities;

public class Tenant : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public Address? Address { get; set; }
    public required string DateFormat {  get; set; }
    public bool IsActive { get; set; }

}
