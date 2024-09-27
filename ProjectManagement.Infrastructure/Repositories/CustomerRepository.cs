using ProjectManagement.Application.Interfaces.Repositories;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Infrastructure.Data;
using ProjectManagement.Infrastructure.Repositories.Base;

namespace ProjectManagement.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
