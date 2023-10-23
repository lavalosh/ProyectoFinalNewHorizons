namespace Muchik.Market.Invoice.Application.Dto;

public class SignInResponseDto : InvoiceDto
{
    public string Token { get; set; } = null!;
}
