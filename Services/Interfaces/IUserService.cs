using soan_backend.Domain;
using soan_backend.Helpers.UserHelpers;

namespace soan_backend.Services.Interfaces;

public interface IUserService
{
    Task<UserJwt> GetToken(User user);
    Task<User?> Login(UserLogin user);

    Task<User?> GetUserToken(int Id);
}