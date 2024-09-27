using ProjectManagement.Domain.Entities.Base;

namespace ProjectManagement.Domain.Entities;

public class Enumerations : EntityBase
{
    public string? Group { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}
