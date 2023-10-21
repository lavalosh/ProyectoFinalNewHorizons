using AutoMapper;
using Muchik.Market.Transaction.Application.dto;
using Muchik.Market.Transaction.Domain.entities;

namespace Muchik.Market.Transaction.Application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<TransactionEntity, TransactionDto>();
        }
    }
}
