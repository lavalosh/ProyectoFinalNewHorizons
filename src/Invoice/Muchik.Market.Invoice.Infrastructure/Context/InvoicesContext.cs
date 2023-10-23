using Microsoft.EntityFrameworkCore;
using Muchik.Market.Invoice.Domain.Entities;
using Muchik.Market.Invoice.Infrastructure.Configuration;

namespace Muchik.Market.Invoice.Infrastructure.Context;

public partial class InvoicesContext : DbContext
{
    public InvoicesContext(DbContextOptions<InvoicesContext> options) : base(options) { }

    public virtual DbSet<Invoices> Invoices { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


//modelBuilder.Entity<Invoices>().ToTable("Invoices");
//base.OnModelCreating(modelBuilder);