using System.Linq.Expressions;

namespace Muchik.Market.Invoice.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> List(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
}