using Microsoft.AspNetCore.Mvc;
using Muchik.Market.Pay.Application.dto;
using Muchik.Market.Pay.Application.interfaces;

namespace Muchik.Market.Pay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PayController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("CreatePayment")]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            _paymentService.CreatePayment(createPaymentDto);
            return Ok();
        }
    }
}