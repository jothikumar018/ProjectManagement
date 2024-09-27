using ProjectManagement.Application.Interfaces.Repositories;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Infrastructure.Data;

namespace ProjectManagement.Infrastructure.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ITenantRepository TenantRepository { get; private set; }

    public ICustomerRepository CustomerRepository { get; private set; }

    public IProjectRepository ProjectRepository { get; private set; }
    public IEnumerationsRepository EnumerationsRepository { get; private set; }



    public async Task<int> Save()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _dbContext.DisposeAsync();
    }
}
