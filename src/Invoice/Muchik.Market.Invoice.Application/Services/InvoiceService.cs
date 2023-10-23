using AutoMapper;
using Muchik.Market.Invoice.Application.Dto;
using Muchik.Market.Invoice.Application.Interfaces;
using Muchik.Market.Invoice.Domain.Interfaces;

namespace Muchik.Market.Invoice.Application.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;
    public InvoiceService(IMapper mapper, IInvoiceRepository invoiceRepository)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
    }
    public ICollection<InvoiceDto> GetAllInvoices()
    {
        var orders = _invoiceRepository.List();
        var ordersDto = _mapper.Map<ICollection<InvoiceDto>>(orders);
        return ordersDto;
    }
}
