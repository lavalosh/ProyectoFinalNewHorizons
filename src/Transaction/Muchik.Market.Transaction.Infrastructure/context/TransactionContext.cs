using Microsoft.EntityFrameworkCore;
using Muchik.Market.Transaction.Infrastructure.entityTypes;
using Muchik.Market.Pay.Infrastructure.context;

namespace Muchik.Market.Transaction.Infrastructure.context
{
    public partial class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TransactionContext> Transaction { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
