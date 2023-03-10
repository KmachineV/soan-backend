using Microsoft.EntityFrameworkCore;
using soan_backend.Data;
using soan_backend.Domain;
using soan_backend.Helpers.UserHelpers;
using soan_backend.Repositories.Repository;

namespace soan_backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <User?> LoginUser(UserLogin user)
        {
            var findUser = await _context.User.Where(a => a.Email == user.Email && a.Password_Bash == user.Password_Bash).FirstOrDefaultAsync();
            if (findUser == null)
                return null;
            return findUser;

        }
    }
}
