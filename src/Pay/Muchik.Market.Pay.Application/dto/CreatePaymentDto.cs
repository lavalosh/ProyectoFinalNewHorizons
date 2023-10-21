using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muchik.Market.Pay.Application.dto
{
    public class CreatePaymentDto
    {
        public int OperationId { get; set; } 
        public int InvoiceId { get; set; }
        public decimal amount { get; set; }
        public DateTime  date { get; set; }
    }
}
