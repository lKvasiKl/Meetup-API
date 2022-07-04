using Business.Models;

namespace Business.Servises.IServices
{
    public interface IOrganizerService
    {
        Task<OrganizerModel> CreateAsync(OrganizerModel model);
        Task<List<OrganizerModel>> GetAllAsync();
        Task<OrganizerModel> GetByIdAsync(int id);
        Task UpdateAsync(int id, OrganizerModel updateModel);
        Task DeleteAsync(int id);
    }
}
