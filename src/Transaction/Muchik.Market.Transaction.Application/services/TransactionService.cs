using AutoMapper;
using Muchik.Market.Transaction.Application.dto;
using Muchik.Market.Transaction.Application.interfaces;
using Muchik.Market.Transaction.Domain.interfaces;
using Muchik.Market.Transaction.Domain.entities;

namespace Muchik.Market.Transaction.Application.services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(IMapper mapper, ITransactionRepository transactionRepository) 
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public ICollection<TransactionDto> GetTransaction(TransactionDto getTransactionDto)
        {
            var objTransaction = _mapper.Map<Domain.entities.TransactionEntity>(getTransactionDto);;
            _transactionRepository.Add(objTransaction);
            var list =  _transactionRepository.List().Where(P => P.TransactionId.Equals(objTransaction.TransactionId));
            return _mapper.Map<ICollection<TransactionDto>>(list);
            
            // _transactionRepository.List().ToList().FindAll(P => P.TransactionId.Equals(objTransaction.TransactionId));
            //return _transactionRepository.List( p => p.);
        }


    }
}
