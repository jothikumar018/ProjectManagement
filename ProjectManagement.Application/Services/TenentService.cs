using AutoMapper;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Application.Interfaces.Security;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Application.Services.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Services;

public class TenentService : BaseService<Tenant>, ITenentService
{
    public TenentService(IUnitOfWork unitOfWork,
                         IMapper mapper,
                         ICurrentUserService currentUserService) : base(unitOfWork, mapper, currentUserService)
    {

    }

    public async Task<Tenant> Get(Guid id)
    {
        var tenant = await UnitOfWork.TenantRepository.Get(id);
        return tenant;
    }

    public async Task<IEnumerable<Tenant>> GetAll()
    {
        var tenants = await UnitOfWork.TenantRepository.GetAll();
        return tenants;
    }

    public async Task Save(Tenant model)
    {
        model = AddAudit(model);
        if (model.Id == Guid.Empty)
        {
            await UnitOfWork.TenantRepository.Add(model);
        }
        else
        {
            UnitOfWork.TenantRepository.Update(model);
        }

        await UnitOfWork.Save();
    }

    public async Task Delete(Guid id)
    {
        await UnitOfWork.TenantRepository.ExecuteDelete(x => x.Id == id);
    }
}
