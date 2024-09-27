using AutoMapper;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Application.Interfaces.Security;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Application.Services.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Services;

public class EnumerationsService : BaseService<Enumerations>, IEnumerationsService
{
    public EnumerationsService(IUnitOfWork unitOfWork,
                               IMapper mapper,
                               ICurrentUserService currentUserService) : base(unitOfWork, mapper, currentUserService)
    {

    }

    public async Task<IEnumerable<Enumerations>> Get(string? group)
    {
        if (!string.IsNullOrEmpty(group))
        {
            var enumerations = UnitOfWork.EnumerationsRepository.Find(x => x.Group == group).AsEnumerable();
            return enumerations;
        }
        else
        {
            var enumerations = await UnitOfWork.EnumerationsRepository.GetAll();
            return enumerations;
        }
    }
}
