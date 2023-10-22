namespace Muchik.Market.Security.Application.Dto;

public class SignInResponseDto : UserDto
{
    public string Token { get; set; } = null!;
}
