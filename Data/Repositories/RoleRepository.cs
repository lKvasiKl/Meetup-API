using Data.Entities;
using Data.Repositories.IRepositories;

namespace Data.Repositories
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(MeetupContext meetupContext) 
            : base(meetupContext)
        {
        }
    }
}
