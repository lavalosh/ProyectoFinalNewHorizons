using AutoMapper;
using Muchik.Market.Invoice.Application.Dto;
using Muchik.Market.Invoice.Domain.Entities;

namespace Muchik.Market.Invoice.Application.Mapping;

public class DtoToEntityProfile : Profile
{
    public DtoToEntityProfile()
    {
        CreateMap<InvoiceDto, Invoices>().ReverseMap();
    }
}