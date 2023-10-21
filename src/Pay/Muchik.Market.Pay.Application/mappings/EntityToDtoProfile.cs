using AutoMapper;
using Muchik.Market.Pay.Application.dto;
using Muchik.Market.Pay.Domain.entities;

namespace Muchik.Market.Pay.Application.mappings
{
    public class EntityToDtoProfile : Profile
    {
       public EntityToDtoProfile() 
       {
            CreateMap<Payment, CreatePaymentDto>();
        }
    }
}
