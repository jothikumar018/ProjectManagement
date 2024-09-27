namespace ProjectManagement.Application.Interfaces.Repositories.Base;

public interface IUnitOfWork : IAsyncDisposable
{
    ITenantRepository TenantRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IProjectRepository ProjectRepository { get; }
    IEnumerationsRepository EnumerationsRepository { get; }

    Task<int> Save();
}
