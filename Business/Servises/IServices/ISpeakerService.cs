using Business.Models;

namespace Business.Servises.IServices
{
    public interface ISpeakerService
    {
        Task<SpeakerModel> CreateAsync(SpeakerModel model);
        Task<List<SpeakerModel>> GetAllAsync();
        Task<SpeakerModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, SpeakerModel updateModel);
        Task DeleteAsync(int id);
    }
}
