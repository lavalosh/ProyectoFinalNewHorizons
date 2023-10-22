using AutoMapper;
using Muchik.Market.Security.Application.Dto;
using Muchik.Market.Security.Domain.Entities;

namespace Muchik.Market.Security.Application.Mapping;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, SignInResponseDto>();
    }
}
