using Muchik.Market.Security.Application.Dto;

namespace Muchik.Market.Security.Application.Interfaces;

public interface ISecurityService
{
    void SignUp(CreateUserDto userDto);
    SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
}
    