using Data.Entities;
using Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class OrganizerRepository : BaseRepository<Organizer, int>, IOrganizerRepository
    {
        public OrganizerRepository(MeetupContext meetupContext)
            : base(meetupContext)
        {

        }

        public async Task<Organizer> GetByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(organizer => organizer.Name == name);
        }
    }
}
