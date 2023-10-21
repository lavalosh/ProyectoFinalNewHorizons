using AutoMapper;
using Muchik.Market.Transaction.Application.dto;
using Muchik.Market.Transaction.Domain.entities;

namespace Muchik.Market.Transaction.Application.mappings
{
    public class DtoToEntityProfile : Profile
    { 
       public DtoToEntityProfile() 
       {
            CreateMap<TransactionDto, TransactionEntity>();
        }
    }
}
