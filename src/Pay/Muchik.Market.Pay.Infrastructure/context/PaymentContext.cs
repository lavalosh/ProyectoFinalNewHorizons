using Microsoft.EntityFrameworkCore;
using Muchik.Market.Pay.Domain.entities;
using Muchik.Market.Pay.Infrastructure.configurations.entityTypes;

namespace Muchik.Market.Pay.Infrastructure.context
{
    public partial class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
