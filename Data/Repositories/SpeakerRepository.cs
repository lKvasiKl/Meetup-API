using Data.Entities;
using Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SpeakerRepository : BaseRepository<Speaker, int>, ISpeakerRepository
    {
        public SpeakerRepository(MeetupContext meetupContext)
            : base(meetupContext)
        {

        }

        public async Task<Speaker> GetByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(speaker => speaker.Name == name);
        }
    }
}
