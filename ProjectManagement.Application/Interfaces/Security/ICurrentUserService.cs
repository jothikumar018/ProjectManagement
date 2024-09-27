namespace ProjectManagement.Application.Interfaces.Security;

public interface ICurrentUserService
{
    Guid UserId { get; }
    Guid TenentId { get; }
    DateTimeOffset CurrentUserTime { get; }
    string DateFormat { get; }
}
