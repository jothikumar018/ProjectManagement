using AutoMapper;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Application.Interfaces.Security;
using ProjectManagement.Domain.Entities.Base;

namespace ProjectManagement.Application.Services.Base;

public abstract class BaseService<T> where T : EntityBase
{
    protected readonly IUnitOfWork UnitOfWork;
    protected IMapper Mapper;
    protected ICurrentUserService CurrentUserService;

    public BaseService(IUnitOfWork unitOfWork,
                       IMapper mapper,
                       ICurrentUserService currentUserService)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
        CurrentUserService = currentUserService;
    }

    public T AddAudit(T model)
    {
        if (model.Id == Guid.Empty)
        {
            model.ModifiedBy = CurrentUserService.UserId;
            model.ModifiedDate = CurrentUserService.CurrentUserTime;
            return model;
        }

        model.Id = Guid.NewGuid();
        model.TenantId = CurrentUserService.TenentId;
        model.CreatedBy = CurrentUserService.UserId;
        model.CreatedDate = CurrentUserService.CurrentUserTime;
        model.ModifiedBy = CurrentUserService.UserId;
        model.ModifiedDate = CurrentUserService.CurrentUserTime;
        return model;
    }

}
