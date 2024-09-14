using System.Linq.Expressions;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Generic;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync() ?? Enumerable.Empty<T>();;
    }

    public async Task<T?> GetById(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> Add(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<T> Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        return entity; 
    }

    public async Task Delete(int id)
    {
        T? entity = await _appDbContext.Set<T>().FindAsync(id);
        if (entity is not null)  _appDbContext.Set<T>().Remove(entity); 
    }

    public async Task<int> Count()
    {
        return await _appDbContext.Set<T>().CountAsync();
    }

    public async Task<IEnumerable<T>> GetWith(string[]? Includes = null, Expression<Func<T, bool>>? Filter = null)
    {
        IQueryable<T> query = _appDbContext.Set<T>();

        if (Filter is not null)  query = query.Where(Filter);
        
        if (Includes is not null)
        {
            foreach (var item in Includes)
            {
                query = query.Include(item);
            }
        }

        return await query.ToListAsync();
    }
 
    public async Task<int> CountWhere(Expression<Func<T, bool>> Filter)
    {
        return await _appDbContext.Set<T>().CountAsync(Filter);
    }

    public async Task<IEnumerable<T>> ListAllAsync(Expression<Func<T, object>>? orderBy = null, int page = 1, int pageSize = 5, params Expression<Func<T, object>>[] includes)
    {
        var query = InitializeQuery(includes);

        if (orderBy != null)
        {
            query = query.OrderBy(orderBy);  // Appointment => Appointment.Order
        }
        if (pageSize > 0)
        {
            query = query.Skip((page-1) * pageSize).Take(pageSize);
        }
        return await query.ToListAsync();
    }
    private IQueryable<T> InitializeQuery(params Expression<Func<T, object>>[] includes)
    {
        // order => order.OrderProducts
        var query = _appDbContext.Set<T>().AsQueryable();
        if(includes.Any())
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return query;
    }
}