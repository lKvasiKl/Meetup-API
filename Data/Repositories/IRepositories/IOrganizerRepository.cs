using Data.Entities;

namespace Data.Repositories.IRepositories
{
    public interface IOrganizerRepository : IBaseRepository<Organizer, int>
    {
        Task<Organizer> GetByNameAsync(string name);
    }
}
