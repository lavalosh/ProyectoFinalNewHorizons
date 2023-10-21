using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muchik.Market.Pay.Domain.entities;

namespace Muchik.Market.Pay.Infrastructure.configurations.entityTypes
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.Property(e => e.OperationId).HasColumnName("id_operation");

            builder.HasKey(e => e.OperationId);

            builder.Property(e => e.InvoiceId).HasColumnName("id_invoice");

            builder.Property(e => e.amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");

            builder.Property(e => e.date)
                .HasColumnType("datetime")
                .HasColumnName("date");
        }
    }
}
