using Business.Models;

namespace Business.Servises.IServices
{
    public interface IEventService
    {
        Task<EventModel> CreateAsync(EventModel model);
        Task<List<EventModel>> GetAllAsync();
        Task<EventModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, EventModel updateModel);
        Task DeleteAsync(int id);
    }
}
