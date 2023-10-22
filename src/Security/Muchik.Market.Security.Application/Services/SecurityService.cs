using AutoMapper;
using Muchik.Market.Security.Application.Dto;
using Muchik.Market.Security.Application.Interfaces;
using Muchik.Market.Security.Domain.Entities;
using Muchik.Market.Security.Domain.Interfaces;
using Muchik.Market.Security.Infrastructure.CrossCutting.Bcrypt;
using Muchik.Market.Security.Infrastructure.CrossCutting.Exceptions;
using Muchik.Market.Security.Infrastructure.CrossCutting.Jwt;

namespace Muchik.Market.Security.Application.Services;

public class SecurityService : ISecurityService
{
    private readonly IMapper _mapper;
    private readonly IJwtManager _jwtManager;
    private readonly IUserRepository _userRepository;
    public SecurityService(IMapper mapper, IJwtManager jwtManager, IUserRepository userRepository)
    {
        _mapper = mapper;
        _jwtManager = jwtManager;
        _userRepository = userRepository;
    }
    public SignInResponseDto SignIn(SignInRequestDto signInRequestDto)
    {
        var currentUser = GetUserByUsername(signInRequestDto.Username);
        if (currentUser == null || !BcryptManager.Verify(signInRequestDto.Password, currentUser.Password)) throw new BusinessException("Username or password incorrect.");

        var signInResponseDto = _mapper.Map<SignInResponseDto>(currentUser);

        signInResponseDto.Token = _jwtManager.GenerateToken(signInResponseDto.Id, signInResponseDto.Username);
        return signInResponseDto;
    }

    public void SignUp(CreateUserDto userDto)
    {
        var currentUser = GetUserByUsername(userDto.Username);
        if (currentUser is not null)
        {
            throw new BusinessException("User alredy exists.");
        }

        var user = _mapper.Map<User>(userDto);
        user.Password = BcryptManager.HashText(user.Password);
        _userRepository.Add(user);
        _userRepository.Save();
    }

    private User GetUserByUsername(string username)
    {
        var currentUser = _userRepository.Find(s => s.Username.Equals(username)).FirstOrDefault();
        return currentUser;
    }
}
