using ProjectManagement.Application.Interfaces.Repositories;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Repositories.Base;

namespace ProjectManagement.Infrastructure.Repositories;

public class EnumerationsRepository : GenericRepository<Enumerations>, IEnumerationsRepository
{
    public EnumerationsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
