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
            return DbSet.Include(user => user.Role).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await DbSet.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
