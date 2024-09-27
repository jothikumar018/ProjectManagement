using ProjectManagement.Application.Interfaces.Repositories;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Repositories.Base;

namespace ProjectManagement.Infrastructure.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
