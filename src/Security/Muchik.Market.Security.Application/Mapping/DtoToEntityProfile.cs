using AutoMapper;
using Muchik.Market.Security.Application.Dto;
using Muchik.Market.Security.Domain.Entities;

namespace Muchik.Market.Security.Application.Mapping;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<CreateUserDto, User>();
    }
}