using soan_backend.Domain;
using soan_backend.Helpers.UserHelpers;

namespace soan_backend.Repositories.Repository
{
    public interface IUserRepository
    {
        Task<User?> LoginUser(UserLogin User);

        Task <User?> GetUserForId(int Id);
    }
}
