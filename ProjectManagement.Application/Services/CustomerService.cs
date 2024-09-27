using AutoMapper;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Application.Interfaces.Security;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Application.Services.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Services;

public class CustomerService : BaseService<Customer>, ICustomerService
{
    public CustomerService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ICurrentUserService currentUserService) : base(unitOfWork, mapper, currentUserService)
    {

    }

    public async Task<Customer> Get(Guid id)
    {
        var customer = await UnitOfWork.CustomerRepository.Get(id);
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        var customers = await UnitOfWork.CustomerRepository.GetAll();
        return customers;
    }

    public async Task Save(Customer model)
    {
        model = AddAudit(model);
        if (model.Id == Guid.Empty)
        {
            await UnitOfWork.CustomerRepository.Add(model);
        }
        else
        {
            UnitOfWork.CustomerRepository.Update(model);
        }

        await UnitOfWork.Save();
    }

    public async Task Delete(Guid id)
    {
        await UnitOfWork.CustomerRepository.ExecuteDelete(x => x.Id == id);
    }

}
