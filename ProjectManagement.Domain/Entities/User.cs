using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.Domain.Entities;

public class User : IdentityUser
{
    public Guid TenentId { get; set; }
    public string? Name { get; set; }
}
