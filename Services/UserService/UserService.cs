using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using soan_backend.Domain;
using soan_backend.Helpers.UserHelpers;
using soan_backend.Repositories.Repository;
using soan_backend.Services.Interfaces;

namespace soan_backend.Services.UserService;

public class UserService : IUserService
{
    private IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public UserService(IConfiguration configuration,IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }
    public async Task<UserJwt> GetToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddDays(7);
        var  securityToken = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );

        UserJwt userJwt = new UserJwt();
        userJwt.Token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        userJwt.Expiration = expiration;

        return userJwt;

    }

    public async  Task<User?> Login(UserLogin user)
    {
        return await _userRepository.LoginUser(user);
    }
}