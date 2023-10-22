using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Muchik.Market.Security.Application.Dto;
using Muchik.Market.Security.Application.Interfaces;

namespace Muchik.Market.Security.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly ISecurityService _securityService;
    public SecurityController(ISecurityService securityService)
    {
        _securityService = securityService;
    }
    [HttpPost("signUp")]
    public IActionResult SignUp([FromBody] CreateUserDto userDto)
    {
        _securityService.SignUp(userDto);
        return Ok();
    }

    [HttpPost("signIn")]
    public IActionResult SignIn([FromBody] SignInRequestDto signInRequestDto)
    {
        return Ok(_securityService.SignIn(signInRequestDto));
    }
}
