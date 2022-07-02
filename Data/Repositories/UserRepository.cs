using Data.Entities;
using Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(MeetupContext meetupContext)
            : base(meetupContext)
        {

        }

        public override Task<User> GetByIdAsync(Guid id)
        {
            return DbSet.Include(user => user.Role)
                        .FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await DbSet.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetByCredentialsAsync(string email, string password)
        {
            var user = DbSet.FirstOrDefault(user => user.Email == email);

            if (user == null)
            {
                return null;
            }
            var isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            return await DbSet.Include(user => user.Role)
                              .FirstOrDefaultAsync(user => user.Email == email && isValidPassword);
        }
    }
}
