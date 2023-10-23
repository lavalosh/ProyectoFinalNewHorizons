using Microsoft.AspNetCore.Mvc;
using Muchik.Market.Invoice.Application.Interfaces;

namespace Muchik.Market.Invoice.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    [HttpGet("getAllInvoices")]
    public IActionResult GetAllInvoices()
    {
        return Ok(_invoiceService.GetAllInvoices());
    }
}
