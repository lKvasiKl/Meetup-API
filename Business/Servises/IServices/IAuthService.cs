using Business.Models;

namespace Business.Servises.IServices
{
    public interface IAuthService
    {
        Task RegisterUserAsync(AuthModel registerRequest);
        Task<LoginSuccessModel> LoginAsync(AuthModel loginRequest);
    }
}
