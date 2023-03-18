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

        public async Task<User> GetUserForId(int Id)
        {
            var findUserForId = await _context.User.Where(a => a.Id == Id)
                .Include(a=> a.Role)
                .FirstOrDefaultAsync();

            if (findUserForId == null)
                return null;

            return findUserForId;
        
        }

        public async Task <User?> LoginUser(UserLogin user)
        {
            var findUser = await _context.User.Where(a => a.Email == user.Email).FirstOrDefaultAsync();
            if (findUser == null)
                return null;
            return findUser;

        }
    }
}
