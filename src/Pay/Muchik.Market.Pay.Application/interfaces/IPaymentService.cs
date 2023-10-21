using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muchik.Market.Pay.Application.dto;
using Muchik.Market.Transaction.Application.dto;

namespace Muchik.Market.Pay.Application.interfaces
{
    public interface IPaymentService
    {
        bool CreatePayment(CreatePaymentDto createPaymentDto);
    }
}
