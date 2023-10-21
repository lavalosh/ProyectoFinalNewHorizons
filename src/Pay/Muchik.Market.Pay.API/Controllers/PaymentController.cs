using Microsoft.AspNetCore.Mvc;
using Muchik.Market.Pay.Application.dto;
using Muchik.Market.Pay.Application.interfaces;

namespace Muchik.Market.Pay.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            _paymentService.CreatePayment(createPaymentDto);
            return Ok();
        }
    }
}