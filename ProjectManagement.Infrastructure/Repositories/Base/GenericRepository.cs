using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectManagement.Application.Interfaces.Repositories.Base;
using ProjectManagement.Domain.Entities.Base;
using ProjectManagement.Infrastructure.Data;
using System.Linq.Expressions;

namespace ProjectManagement.Infrastructure.Repositories.Base;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
{
    private readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    protected GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }


    public async Task<T?> Get(Guid id) => await _dbSet.FindAsync(id);
    public async Task<IEnumerable<T>> GetAll() => await _dbSet.AsNoTracking().ToListAsync();



    private IQueryable<T> ApplyIncludes(IQueryable<T> query, Expression<Func<T, object>>[] includes)
    {
        return includes.Aggregate(query, (current, include) => current.Include(include));
    }

    public async Task<T?> Get(Guid id, params Expression<Func<T, object>>[] includes)
    {
        return await ApplyIncludes(_dbSet.AsNoTracking(), includes).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        return await ApplyIncludes(_dbSet.AsNoTracking(), includes).FirstOrDefaultAsync(expression);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        return ApplyIncludes(_dbSet, includes).Where(expression).AsNoTracking();
    }



    public IQueryable<T> FindAll() => _dbSet.AsNoTracking();
    public IQueryable<T> Find(Expression<Func<T, bool>> expression) =>
           _dbSet.Where(expression).AsNoTracking();



    public async Task Add(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Added;
        await _dbSet.AddAsync(entity);
    }
    public async Task AddRange(IEnumerable<T> entities)
    {
        _dbContext.Entry(entities).State = EntityState.Added;
        await _dbSet.AddRangeAsync(entities);
    }


    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbSet.Update(entity);
    }
    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbContext.Entry(entities).State = EntityState.Modified;
        _dbSet.UpdateRange(entities);
    }
    public async Task ExecuteUpdate(Expression<Func<T, bool>> expression,
        Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls) =>
        await _dbSet.Where(expression).ExecuteUpdateAsync(setPropertyCalls);



    public void Delete(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
        _dbSet.Remove(entity);
    }
    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbContext.Entry(entities).State = EntityState.Deleted;
        _dbSet.RemoveRange(entities);
    }
    public async Task ExecuteDelete(Expression<Func<T, bool>> expression) =>
        await _dbSet.Where(expression).ExecuteDeleteAsync();

}
