using Microsoft.AspNetCore.Mvc;
using Muchik.Market.Transaction.Application.dto;
using Muchik.Market.Transaction.Application.interfaces;

namespace Muchik.Market.Transaction.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpPost("getTransaction")]
        public IActionResult GetAllCustomers([FromBody] TransactionDto transactionDto)
        {
            return Ok(_transactionService.GetTransaction(transactionDto));
        }
    }
}