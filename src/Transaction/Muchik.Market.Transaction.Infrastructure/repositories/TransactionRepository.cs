using Muchik.Market.Transaction.Domain.entities;
using Muchik.Market.Transaction.Domain.interfaces;
using Muchik.Market.Transaction.Infrastructure.context;

namespace Muchik.Market.Infrastructure.repositories
{
    public class TransactionRepository : GenericRepository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(TransactionContext context) : base(context) { }
    }
}
