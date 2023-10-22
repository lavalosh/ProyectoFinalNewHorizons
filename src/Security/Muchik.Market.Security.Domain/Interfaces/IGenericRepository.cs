using System.Linq.Expressions;

namespace Muchik.Market.Security.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    T GetById(string id);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    IQueryable<T> Queryable();
    void Save();
}