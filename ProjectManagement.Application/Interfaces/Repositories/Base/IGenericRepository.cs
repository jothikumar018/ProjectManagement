using System.Linq.Expressions;


namespace ProjectManagement.Application.Interfaces.Repositories.Base;

public interface IGenericRepository<T> where T : class
{
    Task<T?> Get(Guid id);
    Task<IEnumerable<T>> GetAll();

    IQueryable<T> FindAll();
    IQueryable<T> Find(Expression<Func<T, bool>> expression);


    Task Add(T entity);
    Task AddRange(IEnumerable<T> entities);


    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    //Task ExecuteUpdate(Expression<Func<T, bool>> expression,
    //    Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);

    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task ExecuteDelete(Expression<Func<T, bool>> expression);

}

