using Microsoft.EntityFrameworkCore;
using Muchik.Market.Invoice.Domain.Interfaces;
using Muchik.Market.Invoice.Infrastructure.Context;
using System.Linq.Expressions;

namespace Muchik.Market.Invoice.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly InvoicesContext _context;

    public GenericRepository(InvoicesContext context)
    {
        _context = context;
    }

    public IEnumerable<T> List(Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
    {
        IQueryable<T> query = _context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }
}
