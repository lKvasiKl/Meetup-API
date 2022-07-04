using Data.Entities;

namespace Data.Repositories.IRepositories
{
    public interface ISpeakerRepository : IBaseRepository<Speaker, int>
    {
        Task<Speaker> GetByNameAsync(string name);
    }
}
