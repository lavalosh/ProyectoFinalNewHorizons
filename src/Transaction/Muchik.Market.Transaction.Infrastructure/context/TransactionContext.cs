using Microsoft.EntityFrameworkCore;
using Muchik.Market.Transaction.Domain.entities;
using Muchik.Market.Transaction.Infrastructure.entityTypes;

namespace Muchik.Market.Transaction.Infrastructure.context
{
    public partial class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TransactionEntity> Transaction { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
