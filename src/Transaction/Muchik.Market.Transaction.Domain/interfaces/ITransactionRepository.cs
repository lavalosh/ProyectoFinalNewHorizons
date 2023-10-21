using Muchik.Market.Transaction.Domain.entities;

namespace Muchik.Market.Transaction.Domain.interfaces
{
    public interface ITransactionRepository : IGenericRepository<entities.TransactionEntity>
    {
    }
}
