using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Muchik.Market.Transaction.Application.dto;

namespace Muchik.Market.Transaction.Application.interfaces
{
    public interface ITransactionService
    {
        ICollection<TransactionDto> GetTransaction(TransactionDto getTransactionDto);
    }
}
