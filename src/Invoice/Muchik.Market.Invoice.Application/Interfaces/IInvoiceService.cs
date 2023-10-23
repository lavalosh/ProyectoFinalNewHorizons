using Muchik.Market.Invoice.Application.Dto;

namespace Muchik.Market.Invoice.Application.Interfaces;

public interface IInvoiceService
{
    public ICollection<InvoiceDto> GetAllInvoices();
}
    