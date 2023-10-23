using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Muchik.Market.Invoice.Domain.Entities;

namespace Muchik.Market.Invoice.Infrastructure.Configuration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Invoices>
{
    public void Configure(EntityTypeBuilder<Invoices> builder)
    {
        builder.ToTable("invoice");

        builder.Property(e => e.Id)
            .HasColumnType("int")
            .HasColumnName("id_invoice");
        builder.HasKey(c => c.Id);

        builder.Property(e => e.Amount)
            .HasColumnType("decimal")
            .HasColumnName("amount");

        builder.Property(e => e.State)
            .HasColumnType("int")
            .HasColumnName("state");
    }
}