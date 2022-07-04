using Data.Entities;
using Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EventRepository : BaseRepository<Event, int>, IEventRepository
    {
        public EventRepository(MeetupContext meetupContext)
            : base(meetupContext)
        {

        }

        public override async Task<List<Event>> GetAllAsync()
        {
            return await DbSet.Include(events => events.Organizers)
                              .Include(events => events.Speakers)
                              .ToListAsync();
        }

        public override async Task<Event> GetByIdAsync(int id)
        {
            return await DbSet.Include(events => events.Organizers)
                              .Include(events => events.Speakers)
                              .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
