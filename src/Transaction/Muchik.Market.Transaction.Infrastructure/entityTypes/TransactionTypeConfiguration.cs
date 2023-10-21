using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muchik.Market.Transaction.Domain.entities;

namespace Muchik.Market.Transaction.Infrastructure.entityTypes
{
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("payment");

            builder.Property(e => e.TransactionId).HasColumnName("id_transaction");

            builder.HasKey(e => e.TransactionId);

            builder.Property(e => e.InvoiceId).HasColumnName("id_invoice");

            builder.Property(e => e.amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
        }
    }
}
