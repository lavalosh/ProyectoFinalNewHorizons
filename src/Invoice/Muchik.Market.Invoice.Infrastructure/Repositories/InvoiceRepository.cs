using Muchik.Market.Invoice.Domain.Entities;
using Muchik.Market.Invoice.Domain.Interfaces;
using Muchik.Market.Invoice.Infrastructure.Context;

namespace Muchik.Market.Invoice.Infrastructure.Repositories;

public class InvoiceRepository : GenericRepository<Invoices>, IInvoiceRepository
{
    public InvoiceRepository(InvoicesContext context) : base(context) { }
}