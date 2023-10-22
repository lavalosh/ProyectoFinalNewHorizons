using Muchik.Market.Security.Domain.Interfaces;
using Muchik.Market.Security.Infrastructure.Context;
using System.Linq.Expressions;

namespace Muchik.Market.Security.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly SecurityContext _context;

    public GenericRepository(SecurityContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }


    public T GetById(string id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public virtual IQueryable<T> Queryable()
    {
        return _context.Set<T>().AsQueryable<T>();
    }

    public virtual void Save()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception ex)
        {

        }

    }
}
