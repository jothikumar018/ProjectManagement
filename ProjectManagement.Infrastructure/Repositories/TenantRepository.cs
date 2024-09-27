using ProjectManagement.Application.Interfaces.Repositories;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Repositories.Base;

namespace ProjectManagement.Infrastructure.Repositories;

public class TenantRepository : GenericRepository<Tenant>, ITenantRepository
{
    public TenantRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
