using AutoMapper;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Application.Interfaces.Security;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Application.Services.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Services;

public class ProjectService : BaseService<Project>, IProjectService
{
    public ProjectService(IUnitOfWork unitOfWork,
                          IMapper mapper,
                          ICurrentUserService currentUserService) : base(unitOfWork, mapper, currentUserService)
    {

    }

    public async Task<Project> Get(Guid id)
    {
        var project = await UnitOfWork.ProjectRepository.Get(id);
        return project;
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        var projects = await UnitOfWork.ProjectRepository.GetAll();
        return projects;
    }

    public async Task Save(Project model)
    {
        model = AddAudit(model);
        if (model.Id == Guid.Empty)
        {
            await UnitOfWork.ProjectRepository.Add(model);
        }
        else
        {
            UnitOfWork.ProjectRepository.Update(model);
        }

        await UnitOfWork.Save();
    }

    public async Task Delete(Guid id)
    {
        await UnitOfWork.ProjectRepository.ExecuteDelete(x => x.Id == id);
    }
}
