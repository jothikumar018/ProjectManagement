namespace ProjectManagement.Application.Interfaces.Services.Base;

public interface IGenericService<T> where T : class
{
    Task<T> Get(Guid id);
    Task<IEnumerable<T>> GetAll();

    Task Save(T model);
    Task Delete(Guid id);
}
