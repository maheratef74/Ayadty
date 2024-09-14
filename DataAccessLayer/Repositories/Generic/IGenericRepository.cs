using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Generic;

public interface IGenericRepository<T> where T :class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetById(int id);
    Task<T> Add(T entity);
//    Task<T> Update(T entity);
    Task Delete(int id);
    Task<int> Count();
    Task<IEnumerable<T>> GetWith(string[]? Includes = null, Expression<Func<T, bool>>? Filter = null);
    Task<int> CountWhere(Expression<Func<T, bool>> Filter);
    Task<IEnumerable<T>> ListAllAsync(Expression<Func<T, object>>? orderBy = null, int page = 1, int pageSize = 5, params Expression<Func<T, object>>[] includes);
}